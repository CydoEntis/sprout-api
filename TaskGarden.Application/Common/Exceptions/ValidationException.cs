using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Models;

namespace TaskGarden.Application.Common.Exceptions;

public class ValidationException : BaseException
{
    public List<ErrorField> Errors { get; set; } = [];

    public ValidationException(string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, ExceptionTitles.ValidationException, ExceptionMessages.ValidationFailed)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}