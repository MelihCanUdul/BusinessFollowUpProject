using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adınız : ")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Parolanız : ")]
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Parolanızı Tekrar Girin : ")]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        
        public string ConfirmPassword { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        [Required(ErrorMessage = "Email Alanı Boş Geçilemez")]
        public string Email { get; set; }
        [Display(Name = "Adınız : ")]
        [Required(ErrorMessage = "İsim Alanı Boş Geçilemez")]
        public string Name { get; set; }
        [Display(Name = "Soy Adınız : ")]
        [Required(ErrorMessage = "Soyisim Alanı Boş Geçilemez")]
        public string Surname { get; set; }

    }
}
