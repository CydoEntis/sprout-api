﻿using Sprout.Api.Application.Shared.Models;
using Sprout.Application.Common.Exceptions;

namespace Sprout.Api.Infrastructure.Exceptions;

public class BadRequestException : BaseException
{
    public List<ErrorField> Errors { get; set; } = new();

    public BadRequestException(string title, string message, string field, string fieldMessage)
        : base(StatusCodes.Status400BadRequest, title, message)
    {
        Errors.Add(new ErrorField { Field = field, Message = fieldMessage });
    }
}