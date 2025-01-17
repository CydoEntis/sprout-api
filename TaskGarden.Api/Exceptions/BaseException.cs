namespace TaskGarden.Api.Errors;

public class BaseException : Exception
{
    public int StatusCode { get; }
    public string Title { get; }
    public string ErrorMessage { get; }

    public BaseException(int statusCode, string title, string errorMessage)
        : base(errorMessage)
    {
        StatusCode = statusCode;
        Title = title;
    }
}