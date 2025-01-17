﻿using OzelDersApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersApp.WebUI.Models.ViewModels.AdvertModels
{
    public class AdvertUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }

    }
}
