using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailIntegration
{
    interface IEmailService
    {
        /// <summary>
        /// Send Single Email to One Recipient
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        Task SendEmail(string from, string to, string subject, string body);

        /// <summary>
        /// Send Single Email to Multiple Recipients
        /// </summary>
        /// <param name="from"></param>
        /// <param name="toList"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        Task SendEmail(string from, List<string> toList, string subject, string body);

    }
}
