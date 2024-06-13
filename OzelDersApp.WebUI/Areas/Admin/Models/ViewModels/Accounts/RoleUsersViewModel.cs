using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersApp.Entity.Concrete.Identity;

namespace OzelDersApp.WebUI.Areas.Admin.Models.ViewModels.Accounts
{
    public class RoleUsersViewModel
    {
        public RoleUsersViewModel()
        {
            RoleUpdateViewModel = new RoleUpdateViewModel();
        }
        public List<SelectListItem> SelectRoleList { get; set; }
        public List<User> Users { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public RoleUpdateViewModel RoleUpdateViewModel { get; set; }
        public Role Role { get; set; }
    }
}
