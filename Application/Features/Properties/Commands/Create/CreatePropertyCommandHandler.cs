using Application.Abstractions.Data;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Exceptions;
using Application.Mappings;

namespace Application.Features.Properties.Commands.Create
{
    public class CreatePropertyCommandHandler(IUnitOfWork unitOfWork, IPropertyRepository propertyRepository,IHostRepository hostRepository) : IRequestHandler<CreatePropertyCommand, PropertyResponse>
    {
        public async Task<PropertyResponse> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePropertyValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Incorrect data", validationResult);
            }
            
            var host = await hostRepository.GetByIdAsync(request.HostId, cancellationToken);

            if (host is null)
            {
                throw new ValidationException("Create Property failed, Host is null");
            }

            var property = request.MapToProperty();

            await propertyRepository.CreateAsync(property, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return property.MapToResponse();
        }
    }
}