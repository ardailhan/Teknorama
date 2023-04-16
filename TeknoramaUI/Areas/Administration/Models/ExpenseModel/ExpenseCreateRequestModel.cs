using System.ComponentModel.DataAnnotations;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Areas.Administration.Models.ExpenseModel
{
    public class ExpenseCreateRequestModel
    {
        [Required(ErrorMessage = "Expense amount should be given")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Expense description should be given")]
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
