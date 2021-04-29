using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Models
{
    public class UrgencyAddViewModel
    {
        [Display(Name = "Tanım")]
        [Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Description { get; set; }
    }
}
