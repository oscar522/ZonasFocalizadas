using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.
            //var apiKey = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["ES_GEV"]);

            var client = new SendGridClient(ConfigurationManager.AppSettings["ES_GEV"]);

            // Send a Single Email using the Mail Helper with convenience methods and initialized SendGridMessage object
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(ConfigurationManager.AppSettings["ES_FEAM"], ConfigurationManager.AppSettings["ES_FEAN"]),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };
            msg.AddTo(new EmailAddress(message.Destination));

            await client.SendEmailAsync(msg);
        }
    }
}