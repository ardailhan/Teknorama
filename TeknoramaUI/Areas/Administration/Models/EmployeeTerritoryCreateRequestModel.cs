using System.ComponentModel.DataAnnotations;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class EmployeeTerritoryCreateRequestModel
    {
        [Required(ErrorMessage = "This section must not be empty !!!!!")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "This section must not be empty !!!!!")]
        public int TerritoryId { get; set; }
    }
}
