using Microsoft.AspNetCore.Http;

namespace Sprout.Application.Common.Exceptions;


public class OperationException(string title, string message)
    : BaseException(StatusCodes.Status400BadRequest, title, message);