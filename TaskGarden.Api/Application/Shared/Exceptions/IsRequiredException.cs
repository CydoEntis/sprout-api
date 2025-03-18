using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class IsRequiredException(string message)
    : BaseException(StatusCodes.Status400BadRequest, ExceptionTitles.RequiredException, message);