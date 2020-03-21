using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WeVsVirus.Business.Utility;
using WeVsVirus.Models.Entities;

namespace WeVsVirus.Business.Services.EmailServices
{
    public interface IAccountEmailService : IWeVsVirusEmailService
    {
        Task SendDriverSignUpMailAsync(DriverAccount account);
    }

    public class AccountEmailService : WeVsVirusEmailService, IAccountEmailService
    {

        public AccountEmailService(
            IEmailService emailService,
            EmailTemplateIdsConfiguration emailTemplateIds,
            FrontendConfiguration frontendConfiguration,
            UserManager<AppUser> userManager)
            : base(emailService, emailTemplateIds, frontendConfiguration)
        {
            UserManager = userManager;
        }
        private UserManager<AppUser> UserManager { get; }

        public async Task SendDriverSignUpMailAsync(DriverAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var passwordResetToken = await UserManager.GeneratePasswordResetTokenAsync(account.AppUser);
            passwordResetToken = Uri.EscapeDataString(passwordResetToken);

            string receiverMail, receiverName;
            SetReceiver(account.AppUser, out receiverMail, out receiverName);

            var templateId = EmailTemplateIds.DriverSignUpConfirmationLink;
            var templateData = GetEmailBodyDataForDriverSignUpConfirmationLink(account, passwordResetToken);
            await EmailService.SendEmailWithSendGridTemplateAsync(receiverMail, receiverName, templateId, templateData);
        }

        private dynamic GetEmailBodyDataForDriverSignUpConfirmationLink(DriverAccount account, string token)
        {
            return new
            {
                name = account.AppUser.Firstname,
                // TODO don't call the driver Fahrer
                accountType = "Fahrer",
                url = $"{FrontendConfiguration.Url}driver-signup-confirmation?email={account.AppUser.UserName}&token={token}"
            };
        }
    }
}