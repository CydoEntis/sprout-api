using TaskGarden.Api.Constants;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Errors;

public class AlreadyExistsException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new List<ErrorField>();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ExceptionTitles.AlreadyExists, ExceptionMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}