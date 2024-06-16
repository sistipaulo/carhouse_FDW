namespace CarHouse.Models
{
    public class InvoiceFormViewModel
    {
        public Invoice Invoice { get; set; }

        public List<Car> Cars { get; set; }

        public List<Client> Clients { get; set; }

        public List<Seller> Sellers { get; set; }
    }
}
