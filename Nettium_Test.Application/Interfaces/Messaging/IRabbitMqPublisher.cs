namespace Nettium_Test.Application.Interfaces.Messaging
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync(string queueName, string message);
    }
}
