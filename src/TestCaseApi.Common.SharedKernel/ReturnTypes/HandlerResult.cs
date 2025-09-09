namespace TestCaseApi.Common.SharedKernel.ReturnTypes;

public class HandlerResult
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public bool IsFailure => !IsSuccess;
    public int StatusCode { get; }

    protected HandlerResult(bool isSuccess, string error, int statusCode)
    {
        if (isSuccess && error != string.Empty && statusCode != 0)
            throw new InvalidOperationException();
        if (!isSuccess && error == string.Empty && statusCode == 0)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
        StatusCode = statusCode;
    }

    public static HandlerResult Fail(string message)
    {
        return new HandlerResult(false, message, 0);
    }

    public static HandlerResult<T> Fail<T>(string message)
    {
        return new HandlerResult<T>(default(T), false, message, 0);
    }

    public static HandlerResult Fail(string message, int statusCode)
    {
        return new HandlerResult(false, message, statusCode);
    }

    public static HandlerResult<T> Fail<T>(string message, int statusCode)
    {
        return new HandlerResult<T>(default(T), false, message, statusCode);
    }

    public static HandlerResult Ok()
    {
        return new HandlerResult(true, string.Empty, 200);
    }

    public static HandlerResult<T> Ok<T>(T value)
    {
        return new HandlerResult<T>(value, true, string.Empty, 200);
    }
}

public class HandlerResult<T> : HandlerResult
{
    private readonly T _value;

    public T Value
    {
        get
        {
            if (!IsSuccess)
                throw new InvalidOperationException();

            return _value;
        }
    }

    protected internal HandlerResult(T value, bool isSuccess, string error, int statusCode)
        : base(isSuccess, error, statusCode)
    {
        _value = value;
    }
}
