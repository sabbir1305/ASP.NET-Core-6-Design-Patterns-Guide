using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListApp;
using WishListApp.Contracts;
using WishListApp.Internal;

namespace WishlistApp.Tests
{
    public class InMemoryWishListTest
    {
        private readonly Mock<ISystemClock> _systemClockMock = new();
        private readonly InMemoryWishListOptions _options;
        private readonly IWishList sut;
        private readonly string _newItemName = "NewItem";
        public InMemoryWishListTest()
        {
            _options = new InMemoryWishListOptions
            {
                SystemClock = _systemClockMock.Object,
                ExpirationInSeconds = 30
            };
#if TEST_InMemoryWishListRefactored
            sut = new InMemoryWishListRefactored(_options);
#else
            sut = new InMemoryWishList(_options);
#endif
        }

        public class AddOrRefreshAsync : InMemoryWishListTest
        {
            [Fact]
            public async Task Should_create_new_item()
            {
                // Arrange 
                var (_, expectedExpiryTime) = SetUtcNow();

                // Act
                var result = await sut.AddOrRefreshAsync(_newItemName);

                // Assert
                Assert.Equal(_newItemName, result.Name);
                Assert.Equal(1, result.Count);
                Assert.Equal(expectedExpiryTime, result.Expiration);

                var all = await sut.AllAsync();
                Assert.Collection(all,
                    x =>
                    {
                        Assert.Equal(_newItemName, x.Name);
                        Assert.Equal(1, x.Count);
                        Assert.Equal(expectedExpiryTime, x.Expiration);
                    }
                );
            }

            [Fact]
            public async Task Should_increment_Count_of_an_existing_item()
            {
                //Arrange
                const int expectedCount = 2;

                //Act
                var result = await sut.AddOrRefreshAsync(_newItemName);

                //Assert
                Assert.Equal(expectedCount, result.Count);
                var all = await sut.AllAsync();
                Assert.Collection(all, x => Assert.Equal(expectedCount, x.Count));
            }

            [Fact]
            public async Task Should_set_the_Count_of_expired_items_to_1()
            {
                await AddOrRefreshAnExpiredItemAsync(_newItemName);

                var result = await sut.AddOrRefreshAsync(_newItemName);

                Assert.Equal(1, result.Count);
                var all = await sut.AllAsync();
                Assert.Collection(all, x => Assert.Equal(1, x.Count));
            }

            [Fact]
            public async Task Should_remove_expired_items()
            {
                await AddOrRefreshAnExpiredItemAsync("Item1");
                await AddOrRefreshAnExpiredItemAsync("Item2");
                await AddOrRefreshAnExpiredItemAsync("Item3");
                await AddOrRefreshAnExpiredItemAsync("Item4");

                await sut.AddOrRefreshAsync("Item5");

                var result = (await sut.AllAsync()).OrderBy(x => x);
                Assert.Collection(result, 
                    x => Assert.Equal("Item1", x.Name),
                    x => Assert.Equal("Item2", x.Name),
                    x => Assert.Equal("Item3", x.Name),
                    x => Assert.Equal("Item4", x.Name));
            }
        }

        public class AllAsync : InMemoryWishListTest
        {
            [Fact]
            public async Task Should_return_items_ordered_by_Count_Descending()
            {
                // Arrange
                await AddOrRefreshAnItemAsync("Item1");
                await AddOrRefreshAnItemAsync("Item1");
                await AddOrRefreshAnItemAsync("Item1");
                await AddOrRefreshAnItemAsync("Item2");
                await AddOrRefreshAnItemAsync("Item3");
                await AddOrRefreshAnItemAsync("Item3");

                // Act
                var result = await sut.AllAsync();

                // Assert
                Assert.Collection(result,
                    x => Assert.Equal("Item1", x.Name),
                    x => Assert.Equal("Item3", x.Name),
                    x => Assert.Equal("Item2", x.Name)
                );
            }

            [Fact]
            public async Task Should_not_return_expired_items()
            {
                // Arrange
                await AddOrRefreshAnItemAsync("Item1");
                await AddOrRefreshAnExpiredItemAsync("Item2");

                // Act
                var result = await sut.AllAsync();

                // Assert
                Assert.Collection(result,
                    x => Assert.Equal("Item1", x.Name)
                );
            }
        }

        private (DateTimeOffset UtcNow, DateTimeOffset ExpectedExpiryTime) SetUtcNow()
        {
            var utcNow = DateTimeOffset.UtcNow;
            _systemClockMock.Setup(x => x.UtcNow).Returns(utcNow);
            var expectedExpiryTime = utcNow.AddSeconds(_options.ExpirationInSeconds);
            return (utcNow, expectedExpiryTime);
        }

        private async Task AddOrRefreshAnExpiredItemAsync(string itemName)
        {
            var (_, firstExpiredDate) = SetUtcNowToExpired();
            var item = await sut.AddOrRefreshAsync(itemName);
            Assert.Equal(firstExpiredDate, item.Expiration);
            SetUtcNow();
        }

        private (DateTimeOffset UtcNow, DateTimeOffset ExpectedExpiryTime) SetUtcNowToExpired()
        {
            var delay = -(_options.ExpirationInSeconds * 2);
            var utcNow = DateTimeOffset.UtcNow.AddSeconds(delay);
            _systemClockMock.Setup(x => x.UtcNow).Returns(utcNow);
            var expectedExpiryTime = utcNow.AddSeconds(_options.ExpirationInSeconds);
            return (utcNow, expectedExpiryTime);
        }

        private async Task AddOrRefreshAnItemAsync(string itemName)
        {
            var (_, expiredDate) = SetUtcNow();
            var item = await sut.AddOrRefreshAsync(itemName);
            Assert.Equal(expiredDate, item.Expiration);
        }
    }
}
