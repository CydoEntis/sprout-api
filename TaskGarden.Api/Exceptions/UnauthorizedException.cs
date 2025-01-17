namespace TaskGarden.Api.Errors;

public class UnauthorizedException(string message)
    : BaseException(StatusCodes.Status401Unauthorized, ErrorTitles.UnauthorizedException, message);