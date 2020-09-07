using System;

namespace Application
{
    public class EmailSendingService : IEmailSendingService
    {
        public bool Send(string emailContent)
        {
            if(string.IsNullOrEmpty(emailContent))
            {
                return false;
            }
            Console.WriteLine("Email has been sended with content:    " + emailContent);
            return true;
        }
    }
}
