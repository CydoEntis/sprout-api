using Microsoft.AspNetCore.Http;
using Sprout.Application.Common.Constants;

namespace Sprout.Application.Common.Exceptions;

public class PermissionException(string message)
    : BaseException(StatusCodes.Status403Forbidden, ExceptionTitles.PermissionException, message);