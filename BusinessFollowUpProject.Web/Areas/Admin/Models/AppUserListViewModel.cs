using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        [Display(Name = "Ad : ")]
        public string Name { get; set; }
        [Display(Name = "Soyad: ")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }
        [Display(Name ="Email : ")]
        public string Email { get; set; }
        [Display(Name = "Picture : ")]
        public string Picture { get; set; }
    }
}
