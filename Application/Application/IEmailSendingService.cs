namespace Application
{
    public interface IEmailSendingService
    {
        bool Send(string emailContent);
    }
}
