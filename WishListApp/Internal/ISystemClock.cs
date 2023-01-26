namespace WishListApp.Internal
{
    public interface ISystemClock
    {
        DateTimeOffset UtcNow { get; }
    }
}