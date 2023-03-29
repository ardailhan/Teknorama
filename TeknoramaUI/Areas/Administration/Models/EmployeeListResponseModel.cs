using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class EmployeeListResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNO { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal Salary { get; set; }
        public int AppRoleId { get; set; }
        public AppRoleListResponseModel AppRole { get; set; }
    }
}
