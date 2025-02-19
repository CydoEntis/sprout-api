using Microsoft.Extensions.Configuration;
using MimeKit;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Services.Contracts;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TaskGarden.Infrastructure.Services.Email;

public class MailKitService : IEmailService
{
    private readonly string _smtpHost;
    private readonly int _smtpPort;
    private readonly string _email;
    private readonly string _password;

    public MailKitService(IConfiguration configuration)
    {
        _smtpHost = configuration[SMTPConsts.SmtpHost];
        _smtpPort = int.Parse(configuration[SMTPConsts.SmtpPort]);
        _email = configuration[SMTPConsts.Email];
        _password = configuration[SMTPConsts.Password];
    }


    public async Task SendEmailAsync(string preview, string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(preview, _email));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = body 
        };
        message.Body = bodyBuilder.ToMessageBody();

        using (var smtpClient = new SmtpClient())
        {
            try
            {
                await smtpClient.ConnectAsync(_smtpHost, _smtpPort, false);
                await smtpClient.AuthenticateAsync(_email, _password);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}