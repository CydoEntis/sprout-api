namespace TaskGarden.Api.Errors;

public class OperationException(string title, string message)
    : BaseException(StatusCodes.Status400BadRequest, title, message);