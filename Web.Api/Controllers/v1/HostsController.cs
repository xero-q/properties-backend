using Application.Features.Hosts.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
public class HostsController : BaseApiController
{
   [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var getAllHostsQuery = new GetAllHostsQuery();
        var response = await Mediator.Send(getAllHostsQuery, cancellationToken);
        
        return Ok(response);
    }
   
}

