﻿namespace Application.Contracts.Responses;

public sealed class ValidationFailureResponse
{
    public required IEnumerable<ValidationResponse> Errors { get; init; }
}

public sealed class ValidationResponse
{
    public required string Field { get; init; }

    public required string Message { get; init; }
}
