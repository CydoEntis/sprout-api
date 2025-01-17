namespace TaskGarden.Api.Errors;

public class ResourceModificationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ErrorTitles.ResourceModificationException, message)
{
}