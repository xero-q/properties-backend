using Application.Abstractions.Data;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Exceptions;
using Application.Mappings;
using FluentValidation;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Features.Properties.Commands.Create
{
    public class CreatePropertyCommandHandler(IValidator<CreatePropertyCommand> validator, IUnitOfWork unitOfWork, IPropertyRepository propertyRepository,IHostRepository hostRepository) : IRequestHandler<CreatePropertyCommand, PropertyResponse>
    {
        public async Task<PropertyResponse> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAsync(request, cancellationToken);
           
            var host = await hostRepository.GetByIdAsync(request.HostId, cancellationToken);

            if (host is null)
            {
                throw new NotFoundException("Host",request.HostId);
            }

            var property = request.MapToProperty();

            await propertyRepository.CreateAsync(property, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return property.MapToResponse();
        }
    }
}