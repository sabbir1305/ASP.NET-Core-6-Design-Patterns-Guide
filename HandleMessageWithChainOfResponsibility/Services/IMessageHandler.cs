namespace HandleMessageWithChainOfResponsibility.Services
{
    public interface IMessageHandler
    {
        void Handle(Message message);
    }


}
