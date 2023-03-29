using System.ComponentModel.DataAnnotations;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum UserRole
    {
        Admin = 1,
        [Display(Name = "Branch Manager")]
        BranchManager = 2,
        [Display(Name = "Sales Representative")]
        SalesRepresentative = 3,
        [Display(Name = "Warehouse Representative")]
        WarehouseRepresentative = 4,
        [Display(Name = "Accounting Representative")]
        AccountingRepresentative = 5,
        [Display(Name = "Technical Representative")]
        TechnicalServiceRepresentative = 6,
        [Display(Name = "Mobile Sales Representative")]
        MobileSalesRepresentative = 7,
        Member = 8,
        Visitor = 9,
        Employee = 10
    }
}
