namespace TeknoramaUI.Areas.Administration.Models
{
    public class EmployeeTerritoryListResponseModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeListResponseModel Employee { get; set; }
        public int TerritoryId { get; set; }
        public TerritoryListResponseModel Territory { get; set;}
    }
}
