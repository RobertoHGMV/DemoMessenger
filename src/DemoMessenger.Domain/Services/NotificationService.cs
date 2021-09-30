using System.Threading.Tasks;

namespace DemoMessenger.Domain.Services
{
    public class NotificationService : INotificationService
    {
        public async Task NotifyUser(int fromId, int toId, string content)
        {
            await Task.FromResult(true);
        }
    }
}
