using System;
using System.Threading.Tasks;
using WeVsVirus.Business.Utility;
using WeVsVirus.Models.Entities;

namespace WeVsVirus.Business.Services.EmailServices
{
    public interface IWeVsVirusEmailService {}

    public class WeVsVirusEmailService: IWeVsVirusEmailService
    {

        public WeVsVirusEmailService(
            IEmailService emailService,
            EmailTemplateIdsConfiguration emailTemplateIds,
            FrontendConfiguration frontendConfiguration)
        {
            EmailService = emailService;
            EmailTemplateIds = emailTemplateIds;
            FrontendConfiguration = frontendConfiguration;
        }
        protected IEmailService EmailService { get; }
        protected EmailTemplateIdsConfiguration EmailTemplateIds { get; }
        protected FrontendConfiguration FrontendConfiguration { get; }
        protected static void SetReceiver(AppUser user, out string receiverEmail, out string receiverName)
        {
            receiverEmail = user.Email;
            receiverName = $"{user.Firstname} {user.Lastname}";
        }
    }
}