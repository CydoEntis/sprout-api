using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class ResourceCreationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceCreationException, message)
{
}