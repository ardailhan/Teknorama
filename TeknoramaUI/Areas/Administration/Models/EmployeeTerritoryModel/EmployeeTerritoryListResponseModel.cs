using TeknoramaUI.Areas.Administration.Models.EmployeeModel;
using TeknoramaUI.Areas.Administration.Models.TerritoryModel;

namespace TeknoramaUI.Areas.Administration.Models.EmployeeTerritoryModel
{
    public class EmployeeTerritoryListResponseModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeListResponseModel Employee { get; set; }
        public int TerritoryId { get; set; }
        public TerritoryListResponseModel Territory { get; set; }
    }
}
