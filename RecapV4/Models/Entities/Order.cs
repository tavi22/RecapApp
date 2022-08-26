namespace RecapV4.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public double TotalCost { get; set; }

        public string PaymentType { get; set; }

        public string Status { get; set; }

    }
}
