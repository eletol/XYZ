using log4net;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailIntegration
{
    public class EmailService : IEmailService
    {
        #region Properties

        public string ApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["SENDGRID_APIKEY"];
            }
        }

        public SendGridClient SendGridClient { get; set; }

        #endregion

        public EmailService()
        {
            SendGridClient = new SendGridClient(ApiKey);
        }

        public async Task SendEmail(string @from, string to, string subject, string body)
        {
            var mailFrom = new EmailAddress(@from);
            var mailTo = new EmailAddress(to);
            var mailSubject = subject;
            var mailPlainTextContent = body;
            var msg = MailHelper.CreateSingleEmail(mailFrom, mailTo, mailSubject, mailPlainTextContent, string.Empty);
            try
            {
                var response = await SendGridClient.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetLogger(typeof(EmailService));
                logger.Error(ex.Message);
            }

            //var mail = new MailMessage(from, to);
            //var client = new SmtpClient
            //{
            //    Port = 25,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Host = "smtp.google.com"
            //};
            //mail.Subject = subject;
            //mail.Body = body;
            //client.Send(mail);
        }

        public async Task SendEmail(string @from, List<string> tos, string subject, string body)
        {
            var mailFrom = new EmailAddress(@from);
            var mailTos = new List<EmailAddress>();
            var mailSubject = subject;
            var mailPlainTextContent = body;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(mailFrom, mailTos, mailSubject, mailPlainTextContent, string.Empty);
            try
            {
                var response = await SendGridClient.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                var Logger = LogManager.GetLogger(typeof(EmailService));
                Logger.Error(ex.Message);
            }

        }
    }
}
