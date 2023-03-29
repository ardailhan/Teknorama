namespace TeknoramaBackOffice.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        //Navigation Properties
        public virtual List<AppUser> AppUsers { get; set; } = new List<AppUser>();
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
