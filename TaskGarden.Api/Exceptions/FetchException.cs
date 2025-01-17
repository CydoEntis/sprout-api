using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class FetchException(string message)
    : BaseException(StatusCodes.Status500InternalServerError, ExceptionTitles.FetchException, message);