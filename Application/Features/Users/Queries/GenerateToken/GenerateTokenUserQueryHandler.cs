using MediatR;
using Application.Abstractions.Services;
using Domain.Users;

namespace Application.Features.Users.Queries.GenerateToken
{
    public class GenerateTokenUserQueryHandler(IAuthenticationService authenticationService) : IRequestHandler<GenerateTokenUserQuery, string?>
    {
        public async Task<string?> Handle(GenerateTokenUserQuery request, CancellationToken cancellationToken)
        {
            return await authenticationService.GenerateToken(request.Username, cancellationToken);
        }
    }
}