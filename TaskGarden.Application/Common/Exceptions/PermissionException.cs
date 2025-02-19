using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Application.Common.Exceptions;

public class PermissionException(string message)
    : BaseException(StatusCodes.Status403Forbidden, ExceptionTitles.PermissionException, message);