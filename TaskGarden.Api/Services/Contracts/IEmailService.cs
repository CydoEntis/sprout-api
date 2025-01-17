namespace TaskGarden.Api.Services.Contracts;

public interface IEmailService
{
    Task SendEmailAsync(string preview, string toEmail, string subject, string body);
}