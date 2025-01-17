namespace TaskGarden.Api.Errors;

public class InvalidTokenException(string errorMessage) : BaseException(StatusCodes.Status401Unauthorized,
    ErrorTitles.InvalidToken,
    errorMessage);