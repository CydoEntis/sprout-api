namespace Sprout.Api.Infrastructure.Services.Interfaces;

public interface IEmailTemplateService
{
    string GetEmailTemplate(string templateName, Dictionary<string, string> placeholders);
}