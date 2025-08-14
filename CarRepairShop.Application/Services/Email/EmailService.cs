using System.Net;
using System.Net.Mail;
using CarRepairShop.Application.Services.Models;
using Microsoft.Extensions.Options;

namespace CarRepairShop.Application.Services.Email;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(SmtpSettings smtpOptions)
    {
        _smtpSettings = smtpOptions;
    }
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
        client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
        client.EnableSsl = _smtpSettings.EnableSsl;

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpSettings.FromEmail, _smtpSettings.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(to);

        await client.SendMailAsync(mailMessage);
    }
}
