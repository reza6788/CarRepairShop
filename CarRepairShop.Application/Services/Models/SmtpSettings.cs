

using Microsoft.Extensions.Configuration;

namespace CarRepairShop.Application.Services.Models;

public class SmtpSettings
{
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 587;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool EnableSsl { get; set; } = true;

 
    public SmtpSettings(IConfiguration configuration)
    {
        FromEmail = configuration.GetValue<string>("SMTP_FromEmail") ?? string.Empty;
        FromName = configuration.GetValue<string>("SMTP_FromName") ?? string.Empty;
        Host = configuration.GetValue<string>("SMTP_HOST") ?? string.Empty;
        Port = configuration.GetValue<int>("SMTP_PORT", 587); // default 587
        Username = configuration.GetValue<string>("SMTP_USERNAME") ?? string.Empty;
        Password = configuration.GetValue<string>("SMTP_PASSWORD") ?? string.Empty;
        EnableSsl = configuration.GetValue<bool>("SMTP_ENABLE_SSL", true); // default true
    }

    public SmtpSettings()
    {
    }
}