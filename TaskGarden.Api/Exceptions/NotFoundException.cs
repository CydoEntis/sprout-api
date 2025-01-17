using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class NotFoundException(string message)
    : BaseException(StatusCodes.Status404NotFound, ExceptionTitles.NotFoundException, message)
{
}