using System.Threading.Tasks;

namespace DemoMessenger.Domain.Services
{
    public interface INotificationService
    {
        Task NotifyUser(int fromId, int toId, string content);
    }
}
