namespace TaskGarden.Api.Errors;

public class IsRequiredException(string message)
    : ServiceException(StatusCodes.Status400BadRequest, ErrorTitles.RequiredException, message);