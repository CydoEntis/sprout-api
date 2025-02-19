using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Models;

namespace TaskGarden.Application.Common.Exceptions;

public class AlreadyExistsException : BaseException
{
    private List<ErrorField> Errors { get; set; } = new();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ExceptionTitles.AlreadyExists, ExceptionMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}