using TeknoramaUI.Areas.Administration.Models.AppuserModel;

namespace TeknoramaUI.Models.BasketModel
{
    public class BasketListResponseModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUserListResponseModel AppUser { get; set; }
    }
}
