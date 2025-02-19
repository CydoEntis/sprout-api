using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;


public class IsRequiredException(string message)
    : BaseException(StatusCodes.Status400BadRequest, ExceptionTitles.RequiredException, message);