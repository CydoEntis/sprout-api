using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class NotFoundException(string message)
    : BaseException(StatusCodes.Status404NotFound, ExceptionTitles.NotFoundException, message)
{
}