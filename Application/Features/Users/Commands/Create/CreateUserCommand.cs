using Application.Contracts.Responses;
using Domain.Properties;
using MediatR;

namespace Application.Features.Properties.Commands.Create;

public record CreateUserCommand(
    string Username,
    string Password
    ) : IRequest<bool>;