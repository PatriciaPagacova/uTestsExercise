namespace Application
{
    internal class EmailContentCreator : IEmailContentCreator
    {
        public string GetEmailContent(EmailTypes emailType)
        {
            return $"SUBJECT: {emailType.ToString()} | CONTENT: This is email of type: \"{emailType.ToString()}\".";
        }
    }
}