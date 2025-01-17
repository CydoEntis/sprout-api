namespace TaskGarden.Api.Errors;

public class ResourceCreationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ErrorTitles.ResourceCreationException, message)
{
}