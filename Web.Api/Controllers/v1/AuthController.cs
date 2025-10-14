using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Application.Abstractions.Services;
using Application.Features.Properties.Commands.Create;
using Application.Features.Users.Queries.Authenticate;
using Application.Features.Users.Queries.GenerateToken;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
public class AuthController(IUserService userService) : BaseApiController
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var authenticateUserQuery = new AuthenticateUserQuery(request.Username, request.Password);
        
        var user = await Mediator.Send(authenticateUserQuery, cancellationToken);

        if (user is null)
        {
            return Unauthorized(new {success=false,message = ErrorMessages.UsernamePasswordInvalid});
        }
        
        var generateTokenUserQuery = new GenerateTokenUserQuery(request.Username);
        
        var token = await Mediator.Send(generateTokenUserQuery, cancellationToken);

        if (token == null)
        {
            return BadRequest(new {success=false,message=ErrorMessages.TokenNotGenerated});
        }

        var response = new LoginResponse
        {
            Access = token,
        };
            
        return Ok(response);
    }
    
    [HttpPost("signup")]
    public async Task<IActionResult> LoginUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var createUserCommand = new CreateUserCommand(request.Username, request.Password);
        
        var user = await Mediator.Send(createUserCommand, cancellationToken);

        if (user)
        {
            return Ok();
        }

        return BadRequest(new { success = false, message = "Impossible to create the user." });

    }
}