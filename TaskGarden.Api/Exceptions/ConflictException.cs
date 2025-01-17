using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class ConflictException(string message)
    : BaseException(StatusCodes.Status409Conflict, ExceptionTitles.Conflict, message);