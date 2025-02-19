using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Errors;
using TaskGarden.Data.Models;

namespace TaskGarden.Application.Exceptions;


public class ValidationException : BaseException
{
    private List<ErrorField> Errors { get; set; } = [];

    public ValidationException(string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, ExceptionTitles.ValidationException, ExceptionMessages.ValidationFailed)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}