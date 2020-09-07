using System;

namespace Application
{
    internal class EmailSendingService : IEmailSendingService
    {
        public bool Send(string emailContent)
        {
            if(string.IsNullOrEmpty(emailContent))
            {
                return false;
            }
            Console.WriteLine("Email has been sent with content:    " + emailContent);
            return true;
        }
    }
}
