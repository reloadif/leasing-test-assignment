namespace LeasingTestAssignment.Application.Common;

public class Result
{
    public Result()
    {
        IsSuccess = true;
        ErrorMessage = null;
    }

    public Result(string? errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; private set; }

    public string? ErrorMessage { get; private set; }

    public static Result Success() => new();

    public static Result Fail(string? errorMessage) => new(errorMessage);
}
