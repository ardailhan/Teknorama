using System.ComponentModel.DataAnnotations;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class EmployeeUpdateRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must not be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name must not be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "TCNO must not be empty")]
        public string TCNO { get; set; }
        [Required(ErrorMessage = "Phone number must not be empty")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "User role must not be empty")]
        public int AppRoleId { get; set; }
    }
}
