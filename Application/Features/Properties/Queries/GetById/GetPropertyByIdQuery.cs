using Application.Contracts.Responses;
using MediatR;

namespace Application.Features.Properties.Queries.GetById
{
    public record GetPropertyByIdQuery(
        int Id
) : IRequest<PropertyResponse>;
}