using Application.Contracts.Responses;
using Domain.Properties;
using MediatR;

namespace Application.Features.Properties.Commands.Create;

public record CreatePropertyCommand(
    int HostId,
    string Name,
    string Location,
    decimal PricePerNight,
    PropertyStatus Status
) : IRequest<PropertyResponse>;