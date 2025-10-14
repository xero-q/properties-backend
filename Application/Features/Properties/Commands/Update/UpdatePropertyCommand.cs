using Application.Contracts.Responses;
using Domain.Properties;
using MediatR;

namespace Application.Features.Properties.Commands.Update;

public record UpdatePropertyCommand(
    int Id,
    int HostId,
    string Name,
    string Location,
    decimal PricePerNight,
    PropertyStatus Status
) : IRequest<PropertyResponse>;