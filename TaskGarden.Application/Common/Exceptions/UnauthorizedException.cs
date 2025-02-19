using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;


public class UnauthorizedException(string message)
    : BaseException(StatusCodes.Status401Unauthorized, ExceptionTitles.UnauthorizedException, message);