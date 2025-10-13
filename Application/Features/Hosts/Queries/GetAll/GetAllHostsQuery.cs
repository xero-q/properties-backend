using Application.Contracts.Responses;
using MediatR;

namespace Application.Features.Hosts.Queries.GetAll
{
    public record GetAllHostsQuery(
) : IRequest<IEnumerable<HostResponse>>;
}