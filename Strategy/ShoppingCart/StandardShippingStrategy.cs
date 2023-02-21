using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ShoppingCart
{
    internal class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            return orderTotal * 0.01M;
        }
    }
}
