using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Mappings;

namespace Application.Features.Hosts.Queries.GetAll
{
    public class GetAllHostsQueryHandler(IHostRepository hostRepository) : IRequestHandler<GetAllHostsQuery, IEnumerable<HostResponse>>
    {
        public async Task<IEnumerable<HostResponse>> Handle(GetAllHostsQuery request, CancellationToken cancellationToken)
        {
            var resultHosts = await hostRepository.GetAllAsync(cancellationToken);

            return resultHosts.Select(h => h.MapToResponse());
        }
    }
}