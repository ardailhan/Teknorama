using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class EmployeeTerritory
    {
        
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }

        //Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Territory Territory{ get; set; }
    }
}
