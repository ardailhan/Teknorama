using System.ComponentModel.DataAnnotations;

namespace TeknoramaUI.Areas.Administration.Models
{
    public class AppUserUpdateRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username must not be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password must not be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Confirmation needed")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "Role type must be given")]
        public int AppRoleId { get; set; }
    }
}
