using TaskGarden.Api.Constants;

namespace TaskGarden.Api.Errors;

public class PermissionException(string message)
    : BaseException(StatusCodes.Status403Forbidden, ExceptionTitles.PermissionException, message);