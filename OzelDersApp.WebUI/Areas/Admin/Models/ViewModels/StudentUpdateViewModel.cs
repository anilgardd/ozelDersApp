﻿using OzelDersApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersApp.WebUI.Areas.Admin.Models.ViewModels
{
    public class StudentUpdateViewModel
    {
        public int Id { get; set; } 
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılmamalıdır")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır")]
        public string LastName { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılmamalıdır")]
        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı boş bırakılmamalıdır")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası alanı boş bırakılmamalıdır")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş bırakılmamalıdır")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //public List<Teacher> Teachers { get; set; }
        public Image Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
