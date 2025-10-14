using Domain.Users;
using MediatR;

namespace Application.Features.Users.Queries.Authenticate
{
    public record AuthenticateUserQuery(
        string Username,
        string Password
) : IRequest<User?>;
}