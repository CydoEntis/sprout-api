using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class FetchException(string message)
    : BaseException(StatusCodes.Status500InternalServerError, ExceptionTitles.FetchException, message);