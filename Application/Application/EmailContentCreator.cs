using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EmailContentCreator : IEmailContentCreator
    {
        public string GetEmailContent(EmailTypes emailType)
        {
            return $"SUBJECT: {emailType.ToString()} | CONTENT: This is email of type: \"{emailType.ToString()}\".";
        }
    }
}