namespace Application.Contracts.Requests;

public sealed class CreateHostRequest
{
    public required string FullName { get; init; }
    
    public required string Email { get; init; }

    public required string Phone { get; init; }
}