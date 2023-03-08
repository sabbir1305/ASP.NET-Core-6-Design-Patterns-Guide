namespace Mediator.Services
{
    public class Message
    {
        public Message(IColleague from, string content)
        {
            Sender = from ?? throw new ArgumentNullException(nameof(from));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public IColleague Sender { get; }
        public string Content { get; }
    }
}
