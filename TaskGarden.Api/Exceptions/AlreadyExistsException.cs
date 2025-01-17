namespace TaskGarden.Api.Errors;

public class AlreadyExistsException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new List<ErrorField>();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ErrorTitles.AlreadyExists, ErrorMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}