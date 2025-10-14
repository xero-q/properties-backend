using Application.Features.Properties.Queries.GetPaginated;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
public class PropertiesController : BaseApiController
{
   [HttpGet]
    public async Task<IActionResult> GetPaginated(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
    {
        var getPaginatedPropertiesQuery = new GetPaginatedPropertiesQuery(pageNumber, pageSize);
        var response = await Mediator.Send(getPaginatedPropertiesQuery, cancellationToken);
        
        return Ok(response);
    }
}

