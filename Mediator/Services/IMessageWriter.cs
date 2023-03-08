namespace Mediator.Services
{
    public interface IMessageWriter<TMessage>
    {
        void Write(TMessage message);
    }
}
