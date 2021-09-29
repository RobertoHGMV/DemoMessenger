namespace DemoMessenger.Domain.Services
{
    public interface INotificationService
    {
        void NotifyUser(int fromId, int toId, string content);
    }
}
