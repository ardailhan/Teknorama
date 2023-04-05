using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int AppRoleId { get; set; }

        //Navigation properties
        public virtual UserProfile Profile { get; set; }
        public virtual AppRole AppRole { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Issue> Issues { get; set; }
        public virtual List<Basket> Baskets { get; set; }
    }
}
