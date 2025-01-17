using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class ResourceModificationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceModificationException, message)
{
}