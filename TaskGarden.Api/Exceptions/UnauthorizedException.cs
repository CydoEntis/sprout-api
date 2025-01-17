using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class UnauthorizedException(string message)
    : BaseException(StatusCodes.Status401Unauthorized, ExceptionTitles.UnauthorizedException, message);