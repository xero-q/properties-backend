using Application.Contracts.Responses;
using EHR.Application.Wrappers;
using MediatR;

namespace Application.Features.Properties.Queries.GetById
{
    public record GetPropertyByIdQuery(
        int Id
) : IRequest<PropertyResponse>;
}