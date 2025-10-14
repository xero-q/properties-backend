using Application.Abstractions.Data;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Exceptions;
using Application.Mappings;
using FluentValidation;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Features.Properties.Commands.Update
{
    public class UpdatePropertyCommandHandler(IValidator<UpdatePropertyCommand> validator, IPropertyRepository propertyRepository,IHostRepository hostRepository) : IRequestHandler<UpdatePropertyCommand, PropertyResponse>
    {
        public async Task<PropertyResponse> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAsync(request, cancellationToken);
            
            var property = await propertyRepository.GetByIdAsync(request.Id, cancellationToken);

            if (property is null)
            {
                throw new NotFoundException("Property",request.Id);
            }
           
            var host = await hostRepository.GetByIdAsync(request.HostId, cancellationToken);

            if (host is null)
            {
                throw new NotFoundException("Host",request.HostId);
            }

            property.Name = request.Name;
            property.Location = request.Location;
            property.HostId = request.HostId;
            property.PricePerNight = request.PricePerNight;
            property.Status = request.Status;

            await propertyRepository.UpdateAsync(property, cancellationToken);
            
            return property.MapToResponse();
        }
    }
}