using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ShoppingCart
{
    // Define the interface for the strategy
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal orderTotal);
    }
    }
