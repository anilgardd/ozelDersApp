using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersApp.WebUI.Models.ViewModels.AdvertModels
{
    public class AdvertAddViewModel
    {

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }
        public List<SelectListItem> SelectBranchList { get; set; }

        [DisplayName("Ders")]
        public int BranchId { get; set; }
        public string BranchName { get; set; }  

    }
}
