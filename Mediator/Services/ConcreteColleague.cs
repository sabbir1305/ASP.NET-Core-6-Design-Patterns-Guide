namespace Mediator.Services
{
    public class ConcreteColleague : IColleague
    {
        private readonly IMessageWriter<Message> _messageWriter;
        public string Name { get; }

        public ConcreteColleague(string name, IMessageWriter<Message>
messageWriter)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _messageWriter = messageWriter ?? throw new
            ArgumentNullException(nameof(messageWriter));
        }

        public void ReceiveMessage(Message message)
        {
            _messageWriter.Write(message);
        }
    }
}
