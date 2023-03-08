namespace Mediator.Services
{
    public interface IColleague
    {
        string Name { get; }
        void ReceiveMessage(Message message);
    }
}
