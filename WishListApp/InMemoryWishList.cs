using System.Collections.Concurrent;
using WishListApp.Contracts;
using WishListApp.Models;

namespace WishListApp
{
    public class InMemoryWishList : IWishList
    {
        private readonly InMemoryWishListOptions _options;
        private readonly ConcurrentDictionary<string, InternalItem> _items = new();
        public InMemoryWishList(InMemoryWishListOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }
        public Task<WishListItem> AddOrRefreshAsync(string itemName)
        {
            var expirationTime = _options.SystemClock.UtcNow.AddSeconds(_options.ExpirationInSeconds);

            _items.Where(x => x.Value.Expiration < _options.SystemClock.UtcNow)
                .Select(x => x.Key)
                .ToList()
                .ForEach(key => _items.Remove(key, out _));

            var item = _items.AddOrUpdate(itemName, 
                new InternalItem(Count: 1, Expiration: expirationTime),
                (string key, InternalItem item) 
                => item with { Count = item.Count + 1, Expiration = expirationTime});

            var wishListItem = new WishListItem(Name: itemName, Count: item.Count, Expiration: item.Expiration);

            return Task.FromResult(wishListItem);
        }

        public Task<IEnumerable<WishListItem>> AllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
