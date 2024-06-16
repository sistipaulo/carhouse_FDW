namespace CarHouse.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Registration { get; set; }

        public double Salary { get; set; }

        public double CommissionCalc(double value) => value * 0.1;
    }

}
