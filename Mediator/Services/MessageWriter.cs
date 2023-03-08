using System.Text;

namespace Mediator.Services
{
    public class MessageWriter : IMessageWriter<Message>
    {
        public StringBuilder Output { get; } = new StringBuilder();
        public void Write(Message message)
        {
            Output.AppendLine($"[{message.Sender.Name}]: {message.Content}");
        }
    }
}
