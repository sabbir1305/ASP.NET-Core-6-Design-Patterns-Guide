namespace HandleMessageWithChainOfResponsibility.Services
{
    public class DailyAlarmHandler : MultipleMessageHandlerBase
    {
        public DailyAlarmHandler(IMessageHandler? next = null) : base(next)
        {

        }
        protected override string[] HandledMessagesName => new[] {"Sat","Mon"} ;

        protected override void Process(Message message)
        {
            Console.WriteLine(message.Name);
        }
    }
}
