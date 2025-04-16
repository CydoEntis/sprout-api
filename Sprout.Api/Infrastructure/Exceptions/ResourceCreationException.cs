using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class ResourceCreationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceCreationException, message)
{
}