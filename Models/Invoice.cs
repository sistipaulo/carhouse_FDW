namespace CarHouse.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime WarrantyDate { get; set; }

        public double Value { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
