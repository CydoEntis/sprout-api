using Sprout.Api.Application.Shared.Models;
using Sprout.Application.Common.Constants;
using Sprout.Application.Common.Exceptions;

namespace Sprout.Api.Infrastructure.Exceptions;

public class AlreadyExistsException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new();

    public AlreadyExistsException(string field, string fieldMessage)
        : base(StatusCodes.Status409Conflict, ExceptionTitles.AlreadyExists, ExceptionMessages.AlreadyExists)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}