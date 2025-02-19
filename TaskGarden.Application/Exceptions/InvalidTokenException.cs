using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;


public class InvalidTokenException(string errorMessage) : BaseException(StatusCodes.Status401Unauthorized,
    ExceptionTitles.InvalidToken,
    errorMessage);