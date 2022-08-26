namespace RecapV4.Models.Entities
{
    public class Stock
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int AvailableQuantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}
