using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class ConflictException(string message)
    : BaseException(StatusCodes.Status409Conflict, ExceptionTitles.Conflict, message);