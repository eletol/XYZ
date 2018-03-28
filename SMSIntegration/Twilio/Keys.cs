using System.Configuration;

namespace SMSIntegration.Twilio
{
    public static class Keys
    {
        public static string SMSAccountIdentification = ConfigurationManager.AppSettings["Twilio.SMSAccountIdentification"];
        public static string SMSAccountPassword = ConfigurationManager.AppSettings["Twilio.SMSAccountPassword"];
        public static string SMSAccountFrom = ConfigurationManager.AppSettings["Twilio.SMSAccountFrom"];
    }
}
    