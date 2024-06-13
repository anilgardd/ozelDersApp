using OzelDersApp.WebUI.Areas.Admin.Models.ViewModels;

namespace OzelDersApp.WebUI.Models.ViewModels.AdvertModels
{
    public class AdvertListViewModel
    {
        public List<AdvertViewModel> Adverts { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}
