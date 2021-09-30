namespace DemoMessenger.Domain.Configurations
{
    public class RabbitMqConfigMassTransit
    {
        public string RabbitMqRootUri { get; set; }
        public string RabbitMqUri { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NotificationServiceQueue { get; set; }
    }
}
