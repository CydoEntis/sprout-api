namespace TaskGarden.Api.Errors;

public class PermissionException(string message)
    : BaseException(StatusCodes.Status403Forbidden, ErrorTitles.PermissionException, message);