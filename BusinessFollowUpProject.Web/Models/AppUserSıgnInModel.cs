using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Models
{
    public class AppUserSıgnInModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adınız : ")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Parolanız : ")]
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        public string Password { get; set; }
        [Display(Name ="Beni Hatırla")]
        public  bool RememberMe { get; set; }
    }
}
