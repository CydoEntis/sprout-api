using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class ResourceModificationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceModificationException, message)
{
}