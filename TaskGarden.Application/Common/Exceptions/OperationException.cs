using Microsoft.AspNetCore.Http;

namespace TaskGarden.Application.Common.Exceptions;


public class OperationException(string title, string message)
    : BaseException(StatusCodes.Status400BadRequest, title, message);