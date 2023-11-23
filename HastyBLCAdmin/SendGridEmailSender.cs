using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services; // Ensure this namespace is included
using System.Threading.Tasks;

namespace HastyBLCAdmin
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridSettings _sendGridSettings;

        public SendGridEmailSender(IOptions<SendGridSettings> sendGridSettings)
        {
            _sendGridSettings = sendGridSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _sendGridSettings.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_sendGridSettings.FromEmail, _sendGridSettings.FromName);
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
