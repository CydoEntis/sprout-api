namespace TaskGarden.Application.Services.Contracts;


public interface IEmailTemplateService
{
    string GetEmailTemplate(string templateName, Dictionary<string, string> placeholders);
}