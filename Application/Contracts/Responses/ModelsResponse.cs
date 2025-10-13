namespace Application.Contracts.Responses;

public sealed class ModelsResponse
{
    public IEnumerable<HostResponse> Items { get; init; } = [];
}