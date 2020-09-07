namespace Application
{
    public interface IEmailContentCreator
    {
        string GetEmailContent(EmailTypes emailType);
    }
}
