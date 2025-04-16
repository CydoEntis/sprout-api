using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class IsRequiredException(string message)
    : BaseException(StatusCodes.Status400BadRequest, ExceptionTitles.RequiredException, message);