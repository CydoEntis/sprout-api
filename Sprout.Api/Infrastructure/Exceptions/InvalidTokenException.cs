using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class InvalidTokenException(string errorMessage) : BaseException(StatusCodes.Status401Unauthorized,
    ExceptionTitles.InvalidToken,
    errorMessage);