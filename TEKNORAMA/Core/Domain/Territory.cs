namespace TeknoramaBackOffice.Core.Domain
{
    public class Territory
    {
        public int Id { get; set; }
        public string TerritoryDescription { get; set; }

        //Navigation Properties
        public virtual List<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
