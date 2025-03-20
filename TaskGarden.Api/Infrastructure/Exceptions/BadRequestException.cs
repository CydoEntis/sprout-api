using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;

namespace TaskGarden.Api.Infrastructure.Exceptions;

public class BadRequestException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new();

    public BadRequestException(string title, string message, string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, title, message)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}