using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ShoppingCart
{
    public class ShoppingCartFactory
    {
        public static IShoppingCartCheckOut CreateShoppingCart(IShippingStrategy shippingStrategy)
        {
            return new ShoppingCartCheckOut(shippingStrategy);
        }
    }
}
