namespace TeknoramaBackOffice.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Navigation Properties
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
