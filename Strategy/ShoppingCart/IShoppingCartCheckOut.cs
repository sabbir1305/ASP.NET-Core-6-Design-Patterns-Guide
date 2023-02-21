namespace Strategy.ShoppingCart
{
    public interface IShoppingCartCheckOut
    {
        decimal OrderTotal { get; set; }

        decimal CalculateShippingCost();
        void SetShippingStrategy(IShippingStrategy shippingStrategy);
    }
}