namespace TaskGarden.Api.Errors;

public class ValidationException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new List<ErrorField>();

    public ValidationException(string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, ErrorTitles.ValidationException, ErrorMessages.ValidationFailed)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}