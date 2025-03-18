using Microsoft.Extensions.Configuration;
using MimeKit;
using TaskGarden.Application.Services.Contracts;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Collections.Generic;
using System;
using TaskGarden.Api.Infrastructure.Services.Interfaces;

namespace TaskGarden.Api.Infrastructure.Services.Email

{
    public class MailKitService : IEmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _email;
        private readonly string _password;
        private readonly IEmailTemplateService _emailTemplateService;

        public MailKitService(IConfiguration configuration, IEmailTemplateService emailTemplateService)
        {
            _smtpHost = configuration["SMTP:Host"];
            _smtpPort = int.Parse(configuration["SMTP:Port"]);
            _email = configuration["SMTP:Email"];
            _password = configuration["SMTP:Password"];
            _emailTemplateService = emailTemplateService;
        }

        public async Task SendEmailAsync(string preview, string toEmail, string subject, string templateName, Dictionary<string, string> placeholders)
        {
            var emailBody = _emailTemplateService.GetEmailTemplate(templateName, placeholders);
            
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(preview, _email));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = emailBody
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
}
