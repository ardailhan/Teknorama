using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string TCNO{ get; set; }
        public string PhoneNo{ get; set; }
        public string Email{ get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal Salary { get; set; }
        public int AppRoleId { get; set; }

        //Navigation Properties
        public virtual AppRole AppRole { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
