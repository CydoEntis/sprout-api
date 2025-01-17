namespace TaskGarden.Api.Services.Contracts;

public interface IEmailTemplateService
{
    string GetEmailTemplate(string templateName, Dictionary<string, string> placeholders);
}