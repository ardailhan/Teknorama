using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Order Created")]
        Created = 1,
        [Display(Name = "Order Being Prepared")]
        OrderBeingPrepared = 2,
        [Display(Name = "Order Completed")]
        Completed = 3
    }
}
