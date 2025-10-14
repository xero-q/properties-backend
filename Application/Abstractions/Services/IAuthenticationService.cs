using Application.Contracts.Requests;
using Domain.Users;

namespace Application.Abstractions.Services;

public interface IAuthenticationService
{
    Task<User?> AuthenticateUser(string username,string password, CancellationToken cancellationToken = default);

    Task<string?> GenerateToken(string username, CancellationToken cancellationToken = default);
}