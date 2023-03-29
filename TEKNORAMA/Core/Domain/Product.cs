namespace TeknoramaBackOffice.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        //Navigation Properties
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
