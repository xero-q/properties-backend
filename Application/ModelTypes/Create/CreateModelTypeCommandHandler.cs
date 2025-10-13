using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.ModelTypes;
using SharedKernel;

namespace Application.ModelTypes.Create;

internal sealed class CreateModelTypeCommandHandler(
    IApplicationDbContext context
    )
    : ICommandHandler<CreateModelTypeCommand, int>
{
    public async Task<Result<int>> Handle(CreateModelTypeCommand command, CancellationToken cancellationToken)
    {
        var modelType = new ModelType
        {
            Name = command.Name
        };

        modelType.Raise(new ModelTypeCreatedDomainEvent(modelType.Id));

        context.ModelTypes.Add(modelType);

        await context.SaveChangesAsync(cancellationToken);

        return modelType.Id;
    }
}
