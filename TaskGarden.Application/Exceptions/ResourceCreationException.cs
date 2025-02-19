using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;

public class ResourceCreationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceCreationException, message)
{
}