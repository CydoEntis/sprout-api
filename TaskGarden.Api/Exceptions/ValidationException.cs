using TaskGarden.Api.Constants;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Errors;

public class ValidationException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new List<ErrorField>();

    public ValidationException(string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, ExceptionTitles.ValidationException, ExceptionMessages.ValidationFailed)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}