namespace WishListApp.Models
{
    public record class WishListItem(string Name, int Count, DateTimeOffset Expiration);
 
}
