﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sprout.Api.Infrastructure.Exceptions;
using Sprout.Application.Common.Exceptions;

namespace Sprout.Api.Application.Shared.Extensions;

public static class ExceptionExtensions
{
    public static void ConfigureProblemDetails(ProblemDetailsOptions options)
    {
        options.CustomizeProblemDetails = c =>
        {
            if (c.Exception is null)
                return;


            c.ProblemDetails = c.Exception switch
            {
                ValidationException ex => new ValidationProblemDetails(
                    ex.Errors.GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        )
                )
                {
                    Status = StatusCodes.Status400BadRequest
                },

                AlreadyExistsException ex => new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = ex.Message,
                    Status = StatusCodes.Status409Conflict
                },

                UnauthorizedAccessException => new ProblemDetails
                {
                    Title = "Unauthorized",
                    Detail = "Access denied.",
                    Status = StatusCodes.Status401Unauthorized
                },

                NotFoundException ex => new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = ex.Message,
                    Status = StatusCodes.Status404NotFound
                },

                ConflictException ex => new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = ex.Message,
                    Status = StatusCodes.Status409Conflict
                },

                Exception => new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred.",
                    Status = StatusCodes.Status500InternalServerError
                }
            };

            c.ProblemDetails.Extensions.Add("requestId", c.HttpContext.TraceIdentifier);
            c.HttpContext.Response.StatusCode =
                c.ProblemDetails.Status
                ?? StatusCodes.Status500InternalServerError;
        };
    }
}