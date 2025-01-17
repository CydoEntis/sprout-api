namespace TaskGarden.Api.Services.Implementations;

public class EmailManager
{
    private readonly string _templateDirectory;

    public EmailManager()
    {
        var solutionDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
        _templateDirectory = Path.Combine(solutionDirectory, , "Emails", "Templates");
    }
}