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
            DateTimeOffset expirationTime = GetExpirationTime();
            RemoveExpiredItems();

            var item = _items.AddOrUpdate(
                itemName,
                AddValueFactory,
                UpdateValueFactory);

            var wishListItem = MapToWishListItem(itemName, item);

            return Task.FromResult(wishListItem);
        }

        private void RemoveExpiredItems()
        {
            _items.Where(x => x.Value.Expiration < _options.SystemClock.UtcNow)
                .Select(x => x.Key)
                .ToList()
                .ForEach(key => _items.Remove(key, out _));
        }

        private DateTimeOffset GetExpirationTime()
        {
            return _options.SystemClock.UtcNow.AddSeconds(_options.ExpirationInSeconds);
        }

        public Task<IEnumerable<WishListItem>> AllAsync()
        {
            RemoveExpiredItems();
            IEnumerable<WishListItem> items = _items
                .Select(x => MapToWishListItem(x.Key, x.Value))
                .OrderByDescending(x => x.Count)
                .AsEnumerable();
            return Task.FromResult(items);
        }

        private WishListItem MapToWishListItem(string itemName, InternalItem item)
        {
            return new WishListItem(Name: itemName, Count: item.Count, Expiration: item.Expiration);
        }

        private InternalItem AddValueFactory(string key)
        {
            return new(Count: 1, Expiration: GetExpirationTime());
        }

        private InternalItem UpdateValueFactory(string key, InternalItem item)
        => item with { Count = item.Count + 1, Expiration = GetExpirationTime() };
    }
}
