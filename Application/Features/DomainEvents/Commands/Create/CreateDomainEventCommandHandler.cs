using Application.Abstractions.Data;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Exceptions;
using Application.Features.Properties.Commands.Create;
using Application.Mappings;
using FluentValidation;

namespace Application.Features.DomainEvents.Commands.Create
{
    public class CreateDomainEventCommandHandler(IValidator<CreateDomainEventCommand> validator, IDomainEventRepository domainEventRepository,IPropertyRepository propertyRepository,IHostRepository hostRepository) : IRequestHandler<CreateDomainEventCommand, DomainEventResponse>
    {
        public async Task<DomainEventResponse> Handle(CreateDomainEventCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAsync(request, cancellationToken);
           
            var property = await propertyRepository.GetByIdAsync(request.PropertyId, cancellationToken);

            if (property is null)
            {
                throw new NotFoundException("Property",request.PropertyId);
            }

            var eventDomain = request.MapToDomainEvent();

            await domainEventRepository.CreateAsync(eventDomain, cancellationToken);
           
            return eventDomain.MapToResponse();
        }
    }
}