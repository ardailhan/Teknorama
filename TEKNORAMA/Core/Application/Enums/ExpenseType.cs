using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum ExpenseType
    {
        [Display(Name = "Invoice")]
        Invoice = 1,
        [Display(Name = "Technical Expense")]
        TechnicalExpense = 2,
        [Display(Name = "Salary Expense")]
        SalaryPayment = 3,
        [Display(Name = "Other Expense")]
        OtherExpense = 4
    }
}
