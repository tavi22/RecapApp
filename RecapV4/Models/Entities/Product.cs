namespace RecapV4.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public Stock Stock { get; set; }

        public ICollection<ProductShoppingCart> ProductShoppingCarts { get; set; }


    }
}
