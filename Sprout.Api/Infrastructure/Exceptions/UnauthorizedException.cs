using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;


public class UnauthorizedException(string message)
    : BaseException(StatusCodes.Status401Unauthorized, ExceptionTitles.UnauthorizedException, message);