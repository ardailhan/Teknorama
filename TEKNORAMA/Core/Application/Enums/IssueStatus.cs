using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "Open")]
        Open = 1,
        [Display(Name = "Checking")]
        Checking = 2,
        [Display(Name = "Closed")]
        Closed = 3
    }
}
