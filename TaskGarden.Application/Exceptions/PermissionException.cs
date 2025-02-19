using Microsoft.AspNetCore.Http;
using TaskGarden.Api.Constants;

namespace TaskGarden.Application.Exceptions;

public class PermissionException(string message)
    : BaseException(StatusCodes.Status403Forbidden, ExceptionTitles.PermissionException, message);