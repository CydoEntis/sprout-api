using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Errors;
using TaskGarden.Data.Models;

namespace TaskGarden.Application.Exceptions;

public class AlreadyExistsException : BaseException
{
    private List<ErrorField> Errors { get; set; } = new();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ExceptionTitles.AlreadyExists, ExceptionMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}