namespace TaskGarden.Infrastructure.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Title { get; set; }

    public int StatusCode { get; set; }

    public Dictionary<string, string>? Errors { get; set; }

    public ApiResponse(bool success, T? data, string? title, int statusCode, Dictionary<string, string>? errors = null)
    {
        Success = success;
        Data = data;
        Title = title;
        StatusCode = statusCode;
        Errors = errors;
    }

    public static ApiResponse<T> SuccessResponse(T data, string title = "Success", int statusCode = 200)
    {
        return new ApiResponse<T>(true, data, title, statusCode);
    }
    
    public static ApiResponse<object> SuccessResponse(string message, int statusCode = 200)
    {
        return new ApiResponse<object>(true, null, message, statusCode);
    }

    public static ApiResponse<T> ErrorResponse(string title, int statusCode, Dictionary<string, string>? errors = null)
    {
        return new ApiResponse<T>(false, default, title, statusCode, errors);
    }
}