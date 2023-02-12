using HandleMessageWithChainOfResponsibility.Services;

namespace HandleMessageWithChainOfResponsibility.Handlers.Messages
{
    public class DefaultHandler : IMessageHandler
    {
        public void Handle(Message message)
        {
            throw new NotSupportedException($"Messages named '{message.Name}' are not supported.");
        }
    }
}
