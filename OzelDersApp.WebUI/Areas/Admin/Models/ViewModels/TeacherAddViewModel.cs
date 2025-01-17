﻿using OzelDersApp.Entity.Concrete.Identity;
using OzelDersApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDersApp.WebUI.Areas.Admin.Models.ViewModels
{
    public class TeacherAddViewModel
    {
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

        [DisplayName("Mezuniyet")]
        [Required(ErrorMessage = "Mezuniyet alanı boş bırakılmamalıdır")]
        public string Graduation { get; set; }
        //public List<TeacherStudent>? TeacherStudents { get; set; }

        [Required(ErrorMessage = "En az bir branş seçilmelidir")]
        public int[] SelectedBranches { get; set; }
        public List<Branch> Branches { get; set; }


        [DisplayName("Resim")]
        [Required(ErrorMessage = "Resim alanı boş bırakılmamalıdır")]
        public IFormFile Image { get; set; }
    }
}
