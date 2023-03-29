namespace TeknoramaBackOffice.Core.Domain
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNo { get; set; }

        //Navigation Properties
        public virtual List<Order> Orders { get; set; }
    }
}
