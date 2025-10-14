using Domain.Users;
using MediatR;

namespace Application.Features.Users.Queries.GenerateToken
{
    public record GenerateTokenUserQuery(
        string Username
) : IRequest<string?>;
}