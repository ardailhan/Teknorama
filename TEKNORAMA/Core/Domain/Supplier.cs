namespace TeknoramaBackOffice.Core.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Navigation Properties
        public virtual List<Product> Products { get; set; }
    }
}
