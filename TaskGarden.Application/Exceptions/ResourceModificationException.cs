using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;

public class ResourceModificationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceModificationException, message)
{
}