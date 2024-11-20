namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice => ShoppingCartItems.Sum(s => s.Price * s.Quantity);
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart() { }
    }
}
