using System.ComponentModel.DataAnnotations;

namespace TeknoramaBackOffice.Core.Application.Enums
{
    public enum Gender
    {
        [Display(Name = "Woman")]
        Female = 1,
        [Display(Name = "Man")]
        Male = 2,
        [Display(Name = "Unspecified")]
        Unspecified = 3
    }
}
