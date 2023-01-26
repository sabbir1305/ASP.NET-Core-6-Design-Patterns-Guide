using WishListApp.Models;

namespace WishListApp.Contracts
{
    public interface IWishList
    {
        Task<WishListItem> AddOrRefreshAsync(string itemName);
        Task<IEnumerable<WishListItem>> AllAsync();
    }
}
