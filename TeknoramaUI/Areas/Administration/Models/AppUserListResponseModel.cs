namespace TeknoramaUI.Areas.Administration.Models
{
    public class AppUserListResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int AppRoleId { get; set; }
        public AppRoleListResponseModel AppRole { get; set; }
    }
}
