using TeknoramaUI.Areas.Administration.Models.AppuserModel;
using TeknoramaUI.Areas.Administration.Models.OrderModel;

namespace TeknoramaUI.Models.BasketModel
{
    public class BasketListResponseModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUserListResponseModel AppUser { get; set; }
    }
}
