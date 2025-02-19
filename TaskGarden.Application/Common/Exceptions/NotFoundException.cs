using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class NotFoundException(string message)
    : BaseException(StatusCodes.Status404NotFound, ExceptionTitles.NotFoundException, message)
{
}