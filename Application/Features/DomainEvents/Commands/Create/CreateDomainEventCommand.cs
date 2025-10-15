using Application.Contracts.Responses;
using Domain.Properties;
using MediatR;

namespace Application.Features.Properties.Commands.Create;

public record CreateDomainEventCommand(
    int PropertyId,
    string EventType,
    string PayloadJSON
) : IRequest<DomainEventResponse>;