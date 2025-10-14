using Application.Contracts.Requests;
using Application.Features.Properties.Commands.Create;
using Application.Features.Properties.Commands.Delete;
using Application.Features.Properties.Commands.Update;
using Application.Features.Properties.Queries.GetById;
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
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id,CancellationToken cancellationToken)
    {
        var getPropertyByIdQuery = new GetPropertyByIdQuery(id);
        var response = await Mediator.Send(getPropertyByIdQuery, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePropertyRequest request,CancellationToken cancellationToken)
    {
        var createPropertyCommand = new CreatePropertyCommand(request.HostId, request.Name, request.Location,
            request.PricePerNight, request.Status);
        
        var response = await Mediator.Send(createPropertyCommand, cancellationToken);
        
        return CreatedAtAction(
            nameof(GetById),    
            new { id = response.Id },     
            response                        
        );
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Create([FromBody] UpdatePropertyRequest request,[FromRoute] int id, CancellationToken cancellationToken)
    {
        var updatePropertyCommand = new UpdatePropertyCommand(id, request.HostId, request.Name, request.Location,
            request.PricePerNight, request.Status);
        
        var response = await Mediator.Send(updatePropertyCommand, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Create([FromRoute] int id, CancellationToken cancellationToken)
    {
        var deletePropertyCommand = new DeletePropertyCommand(id);
        
        await Mediator.Send(deletePropertyCommand, cancellationToken);
        
        return Ok();
    }
}

