using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;

public class UnauthorizedException(string message)
    : BaseException(StatusCodes.Status401Unauthorized, ExceptionTitles.UnauthorizedException, message);