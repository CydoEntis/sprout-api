namespace TaskGarden.Api.Errors;

public class FetchException(string message)
    : BaseException(StatusCodes.Status500InternalServerError, ErrorTitles.FetchException, message);