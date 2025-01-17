namespace TaskGarden.Api.Errors;

public class NotFoundException(string message)
    : BaseException(StatusCodes.Status404NotFound, ErrorTitles.NotFoundException, message)
{
}