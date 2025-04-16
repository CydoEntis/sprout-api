namespace Sprout.Api.Infrastructure.Services.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string preview, string toEmail, string subject, string templateName,
        Dictionary<string, string> placeholders);
}