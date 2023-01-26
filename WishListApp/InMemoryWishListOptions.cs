

using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using WishListApp.Internal;

namespace WishListApp
{
    public class InMemoryWishListOptions : IConfigureOptions<InMemoryWishListOptions>, IValidateOptions<InMemoryWishListOptions>
    {
        [NotNull]
        public ISystemClock? SystemClock { get; set; }
        public int ExpirationInSeconds { get; set; }
        void IConfigureOptions<InMemoryWishListOptions>.Configure(InMemoryWishListOptions options)
        {
            if (options.SystemClock == default)
            {
                options.SystemClock = new SystemClock();
            }
            if (options.ExpirationInSeconds == default)
            {
                options.ExpirationInSeconds = 30;
            }
        }

        public ValidateOptionsResult Validate(string name, InMemoryWishListOptions options)
        {
            if (options.SystemClock == default)
            {
                return ValidateOptionsResult.Fail("SystemClock cannot be null.");
            }
            if (options.ExpirationInSeconds <= 0)
            {
                return ValidateOptionsResult.Fail("ExpirationInSeconds should be greater than 0.");
            }
            return ValidateOptionsResult.Success;
        }
    }
}
