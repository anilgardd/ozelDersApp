﻿using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDersApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersApp.WebUI.Models.ViewModels.AccountModels
{
    public class TeacherRegisterViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="Ad alanı boş bırakılmamalıdır")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır")]
        public string LastName { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılmamalıdır")]
        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılmamalıdır")]
        [DataType(DataType.Date)]

        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır")]
        public string City { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Telefon alanı boş bırakılmamalıdır")]
        public string Phone { get; set; }
        public string Graduation { get; set; }
        public decimal? Price { get; set; }
        public IFormFile Image { get; set; }

        public int[] SelectedBranches { get; set; }
        public List<Branch> Branches { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş bırakılmamalıdır")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı boş bırakılmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı boş bırakılmamalıdır")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
    }
}
