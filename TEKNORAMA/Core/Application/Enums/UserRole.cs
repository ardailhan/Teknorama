using System.ComponentModel.DataAnnotations;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum UserRole
    {
        Admin = 1,
        Member = 2,
        [Display(Name = "Branch Manager")]
        BranchManager = 3,
        [Display(Name = "Sales Representative")]
        SalesRepresentative = 4,
        [Display(Name = "Warehouse Representative")]
        WarehouseRepresentative = 5,
        [Display(Name = "Accounting Representative")]
        AccountingRepresentative = 6,
        [Display(Name = "Technical Representative")]
        TechnicalServiceRepresentative = 7,
        [Display(Name = "Mobile Sales Representative")]
        MobileSalesRepresentative = 8,
        Visitor = 9,
        Employee = 10
    }
}
