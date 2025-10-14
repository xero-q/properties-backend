using MediatR;
using Application.Abstractions.Services;
using Domain.Users;

namespace Application.Features.Users.Queries.Authenticate
{
    public class AuthenticateUserQueryHandler(IAuthenticationService authenticationService) : IRequestHandler<AuthenticateUserQuery, User?>
    {
        public async Task<User?> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            return await authenticationService.AuthenticateUser(request.Username, request.Password, cancellationToken);
        }
    }
}