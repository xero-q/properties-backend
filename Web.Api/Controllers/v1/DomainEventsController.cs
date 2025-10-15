using Application.Contracts.Requests;
using Application.Features.Properties.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
public class DomainEventsController : BaseApiController
{
   [HttpPost]
   [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateDomainEventRequest request,CancellationToken cancellationToken)
    {
        var createDomainEvent = new CreateDomainEventCommand(request.PropertyId,request.EventType,request.PayloadJSON);
        var response = await Mediator.Send(createDomainEvent, cancellationToken);
        
        return Ok(response);
    }
}

