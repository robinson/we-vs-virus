using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using WeVsVirus.Business.Utility;

namespace WeVsVirus.Business.Services.EmailServices
{
    /// <summary>
    /// This interface is for sending emails through a SMTP-client or via SendGrid.
    /// Set the data of your SMTP-server OR the Api Key of your SendGrid account in appsettings.json like the following.
    /// 
    /// "Email": {
    ///     "FromEmail": "your@email.de",
    ///     "FromName": "Your Name",
    ///     "SendGridApiKey": "YourApiKey"
    ///     }
    ///     </summary>
    public interface IEmailService
    {
        Task SendEmailWithSendGridTemplateAsync(string email, string toName, string templateId, object dynamicTemplateData);
    }

    public class EmailService : IEmailService
    {
        public EmailService(IConfiguration configuration)
        {
            Configuration = new EmailConfiguration();
            configuration.GetSection("Email").Bind(Configuration);
        }

        public EmailConfiguration Configuration { get; }

        public async Task SendEmailWithSendGridTemplateAsync(string email, string toName, string templateId, object dynamicTemplateData)
        {
            await UseSendGridTemplateAsync(email, toName, templateId, dynamicTemplateData);
        }

        private async Task UseSendGridTemplateAsync(string email, string toName, string templateId, object dynamicTemplateData)
        {
            var emailMessage = new SendGridMessage();
            emailMessage.SetFrom(new EmailAddress(Configuration.FromEmail, Configuration.FromName));
            emailMessage.AddTo(new EmailAddress(email, toName));
            emailMessage.SetTemplateId(templateId);
            emailMessage.SetTemplateData(dynamicTemplateData);

            var client = new SendGridClient(Configuration.SendGridApiKey);
            await client.SendEmailAsync(emailMessage);
        }
    }
}