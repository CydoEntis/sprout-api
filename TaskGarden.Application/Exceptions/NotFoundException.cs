using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;


public class NotFoundException(string message)
    : BaseException(StatusCodes.Status404NotFound, ExceptionTitles.NotFoundException, message)
{
}