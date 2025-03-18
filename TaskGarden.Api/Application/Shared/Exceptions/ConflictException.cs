using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class ConflictException(string message)
    : BaseException(StatusCodes.Status409Conflict, ExceptionTitles.Conflict, message);