using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class ResourceModificationException(string message) : BaseException(StatusCodes.Status500InternalServerError,
    ExceptionTitles.ResourceModificationException, message)
{
}