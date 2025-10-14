using Application.Contracts.Requests;
using Application.Features.Properties.Commands.Create;
using Application.Features.Properties.Queries.GetPaginated;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
public class PropertiesController : BaseApiController
{
   [HttpGet]
    public async Task<IActionResult> GetPaginated(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10, string? search=null)
    {
        var getPaginatedPropertiesQuery = new GetPaginatedPropertiesQuery(pageNumber, pageSize, search);
        var response = await Mediator.Send(getPaginatedPropertiesQuery, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePropertyRequest request,CancellationToken cancellationToken)
    {
        var createPropertyCommand = new CreatePropertyCommand(request.HostId, request.Name, request.Location,
            request.PricePerNight, request.Status);
        
        var response = await Mediator.Send(createPropertyCommand, cancellationToken);
        
        return Ok(response);
    }
}

