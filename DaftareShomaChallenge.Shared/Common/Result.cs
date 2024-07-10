using DaftareShomaChallenge.Shared.Common;

namespace DaftareShomaChallenge.Shared.Common;
public class Result
{
    internal Result(bool isSuccess, IEnumerable<string>? errors)
    {
        IsSuccess = isSuccess;
        Description = isSuccess ? Messages.SuccessMessage : Messages.ErrorMessage;
        Errors = errors != null ? errors.ToArray() : null;
    }

    public bool IsSuccess { get; init; }

    public string[]? Errors { get; init; }
    public string Description { get; init; }

    public static Result Success()=> 
        new(true, Array.Empty<string>());
    

    public static Result Failure(IEnumerable<string>? errors = null)=> 
        new(false, errors);

    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, null);


    public static Result<TValue?> Failure<TValue>(TValue? value = default, string[]? error = null) =>
        new(value, false, error);
}


public class Result<TData> : Result
{

    protected internal Result(TData? data, bool isSuccess, string[]? error)
        : base(isSuccess, error)
        => Data = data;

    public TData? Data { get; }

    public static implicit operator Result<TData>(TData data) => Success(data);
}