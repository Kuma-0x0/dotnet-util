using System.Net;

namespace Models.Results;

public static class HttpResultFactory
{
    public static HttpResult<object?> CreateSuccessResult(HttpStatusCode statusCode) => new(statusCode, null, null, null);

    public static HttpResult<T> CreateSuccessResult<T>(HttpStatusCode statusCode, T value) => new(statusCode, value, null, null);

    public static HttpResult<T> CreateWarningResult<T>(HttpStatusCode statusCode, string warning) => new(statusCode, default, warning, null);

    public static HttpResult<T> CreateWarningResult<T>(HttpStatusCode statusCode, T value, string warning) => new(statusCode, value, warning, null);

    public static HttpResult<object?> CreateErrorResult(HttpStatusCode statusCode, string error) => new(statusCode, null, null, error);
}

public record HttpResult<T>(
    HttpStatusCode StatusCode,
    T? Value,
    string? Warning,
    string? Error
) : Result<T>(
    IsSuccess: 200 <= (int)StatusCode && (int)StatusCode <= 299,
    Value,
    Warning,
    Error
);
