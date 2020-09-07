using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailContentCreator = new EmailContentCreator();
            var emailSendingService = new EmailSendingService();
            var emailSender = new EmailSender(emailContentCreator, emailSendingService);
            emailSender.EmailSent += OnEmailSent;
            emailSender.SendEmail(EmailTypes.Warning, new EnToSkTranslator());
            emailSender.SendEmail(EmailTypes.Warning, new EnToCzTranslator());

            while (!Console.KeyAvailable)
            {
            }
        }

        private static void OnEmailSent(object sender, EventArgs e)
        {
            Console.WriteLine("New email successfully sent!");
        }
    }
}
