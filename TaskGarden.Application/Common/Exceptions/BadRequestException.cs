using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Models;

namespace TaskGarden.Application.Common.Exceptions;

public class BadRequestException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new();

    public BadRequestException(string title, string message, string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, title, message)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}