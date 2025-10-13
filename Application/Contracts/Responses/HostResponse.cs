namespace Application.Contracts.Responses;

public sealed class HostResponse
{
    public int Id { get; init; }
    
    public required string FullName { get; init; }
    
    public required string Email { get; init; }

    public required string Phone { get; init; }

}