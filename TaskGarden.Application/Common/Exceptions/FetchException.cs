using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class FetchException(string message)
    : BaseException(StatusCodes.Status500InternalServerError, ExceptionTitles.FetchException, message);