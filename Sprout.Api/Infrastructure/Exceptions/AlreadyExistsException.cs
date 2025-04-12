using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;

namespace TaskGarden.Api.Infrastructure.Exceptions;

public class AlreadyExistsException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ExceptionTitles.AlreadyExists, ExceptionMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}