using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class IsRequiredException(string message)
    : BaseException(StatusCodes.Status400BadRequest, ExceptionTitles.RequiredException, message);