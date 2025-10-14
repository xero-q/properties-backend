using MediatR;

namespace Application.Features.Properties.Commands.Delete;

public record DeletePropertyCommand(
    int Id
) : IRequest<bool>;