using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;


public class ConflictException(string message)
    : BaseException(StatusCodes.Status409Conflict, ExceptionTitles.Conflict, message);