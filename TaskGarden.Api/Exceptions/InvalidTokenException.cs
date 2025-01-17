using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class InvalidTokenException(string errorMessage) : BaseException(StatusCodes.Status401Unauthorized,
    ExceptionTitles.InvalidToken,
    errorMessage);