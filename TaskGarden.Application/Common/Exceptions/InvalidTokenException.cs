using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class InvalidTokenException(string errorMessage) : BaseException(StatusCodes.Status401Unauthorized,
    ExceptionTitles.InvalidToken,
    errorMessage);