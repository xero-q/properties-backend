using Application.ModelTypes.Create;
using Application.Todos.Create;
using Domain.Todos;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Todos;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; }
      
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("todos", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateModelTypeCommand
            {
                Name = request.Name
            };

            Result<int> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        });
        // .WithTags(Tags.Todos)
        // .RequireAuthorization();
    }
}