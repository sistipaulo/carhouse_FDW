namespace CarHouse.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufacturingYear { get; set; }

        public DateTime ModelYear { get; set; }

        public long Chassi { get; set; }

        public double Price { get; set; }

    }
}
