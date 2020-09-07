using System;

namespace Application
{
    public class EmailSender
    {
        public event EventHandler EmailSent;
        private IEmailContentCreator myEmailContentCreator;
        private readonly IEmailSendingService myEmailSendingService;

        public EmailSender(IEmailContentCreator emailContentCreator, IEmailSendingService emailSendingService)
        {
            myEmailContentCreator = emailContentCreator ?? throw new ArgumentNullException(nameof(emailContentCreator));
            myEmailSendingService = emailSendingService ?? throw new ArgumentNullException(nameof(emailSendingService));
        }

        public bool SendEmail(EmailTypes type, ITranslator translator)
        {
            if (translator == null)
            {
                throw new ArgumentNullException(nameof(translator));
            }
            string emailContent = myEmailContentCreator.GetEmailContent(type);
            string translatedContent = translator.Translate(emailContent);
            if(myEmailSendingService.Send(translatedContent))
            {
                EmailSent?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
        }
    }
}
