namespace RecapV4.Models.Entities
{
    public class ShoppingCart
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int NumberOfItems { get; set; }

        public int TotalCost { get; set; }

        public string? Status { get; set; }

        public ICollection<ProductShoppingCart> ProductShoppingCarts { get; set; }

        public Order? Order { get; set; }

    }
}
