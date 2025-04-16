namespace Sprout.Api.Application.Shared.Models;


public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public Dictionary<string, string>? Errors { get; set; }

    private ApiResponse(bool success, T? data, string? message, int statusCode,
        Dictionary<string, string>? errors = null)
    {
        Success = success;
        Data = data;
        Message = message;
        StatusCode = statusCode;
        Errors = errors;
    }

    public static ApiResponse<T> SuccessWithData(T data, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse<T>(true, data, message, statusCode);
    }

    public static ApiResponse<string> SuccessWithMessage(string message, int statusCode = 200)
    {
        return new ApiResponse<string>(true, null, message, statusCode);
    }

    public static ApiResponse<T> FailureWithData(string message, int statusCode = 400,
        Dictionary<string, string>? errors = null)
    {
        return new ApiResponse<T>(false, default, message, statusCode, errors);
    }

    public static ApiResponse<string> FailureWithMessage(string message, int statusCode = 400)
    {
        return new ApiResponse<string>(false, null, message, statusCode);
    }
}