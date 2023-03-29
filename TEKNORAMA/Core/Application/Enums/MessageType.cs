using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum MessageType
    {
        [Display(Name = "Want to be a salesman")]
        Sale = 1,
        [Display(Name = "Want to be a Teknoroma partner")]
        Partnership = 2,
        [Display(Name = "Just want to give some advice about the services")]
        Advice = 3
    }
}
