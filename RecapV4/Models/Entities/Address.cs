namespace RecapV4.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string StreetName { get; set; }

        public int Number { get; set; }

        public string Details { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
