using DemoMessenger.Domain.Models;
using DemoMessenger.Domain.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DemoMessenger.Api.MassTransit.Consumers
{
    public class MessageConsumer : IConsumer<Message>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(IServiceProvider serviceProvider, ILogger<MessageConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Message> context)
        {
            await NotifyUser(context.Message);
        }

        public async Task NotifyUser(Message message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                 await notificationService.NotifyUser(message.FromId, message.ToId, message.Content);

                _logger.LogInformation($"Nova mensagem recebida: {message.Content}");
            }
        }
    }
}
