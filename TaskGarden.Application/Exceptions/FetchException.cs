using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;


public class FetchException(string message)
    : BaseException(StatusCodes.Status500InternalServerError, ExceptionTitles.FetchException, message);