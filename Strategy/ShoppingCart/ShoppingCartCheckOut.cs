using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ShoppingCart
{
    public class ShoppingCartCheckOut : IShoppingCartCheckOut
    {
        private IShippingStrategy _shippingStrategy;
        public decimal OrderTotal { get; set; }

        public ShoppingCartCheckOut(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        public decimal CalculateShippingCost()
        {
            return _shippingStrategy.CalculateShippingCost(OrderTotal);
        }

        public void SetShippingStrategy(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }
    }
}
