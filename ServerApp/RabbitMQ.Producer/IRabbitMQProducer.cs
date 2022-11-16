namespace ServerApp.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        void SendMessage<T> (T message);
    }
}
