using System.Diagnostics.CodeAnalysis;

namespace Models.Results;

public static class ResultFactory
{
    private static readonly Result<object?> _defaultSuccessResult = new(true, null, null, null);

    public static Result<object?> CreateSuccessResult() => _defaultSuccessResult;

    public static Result<T> CreateSuccessResult<T>(T value) => new(true, value, null, null);

    public static Result<T> CreateWarningResult<T>(string warning) => new(true, default, warning, null);

    public static Result<T> CreateWarningResult<T>(T value, string warning) => new(true, value, warning, null);

    public static Result<object?> CreateErrorResult(string error) => new(false, null, null, error);
}

public record Result<T>(
    [property: MemberNotNullWhen(false, nameof(Result<T>.Error))]
    bool IsSuccess,
    T? Value,
    string? Warning,
    string? Error)
{
    public virtual bool TryGetValue([NotNullWhen(true)] out T? value)
    {
        value = Value;
        return IsSuccess;
    }
}
