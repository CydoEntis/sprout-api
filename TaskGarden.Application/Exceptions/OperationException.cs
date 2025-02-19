using Microsoft.AspNetCore.Http;

namespace TaskGarden.Application.Exceptions;

public class OperationException(string title, string message)
    : BaseException(StatusCodes.Status400BadRequest, title, message);