using AlkinanaPharmaManagment.Application.Abstractions.Email;
using AlkinanaPharmaManagment.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSetting Setting { get; set; }
    public EmailSender(IOptions<EmailSetting> setting)
    {
        this.Setting = setting.Value;
    }
    public async Task<bool> SendEmailAsync(EmailMessage email)
    {
        var client = new SendGridClient(Setting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = Setting.FromAddress,
            Name = Setting.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }
}
