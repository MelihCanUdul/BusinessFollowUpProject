using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Models
{
    public class UrgencyUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tanım")]

        [Required(ErrorMessage = "Tanım alanı gereklidir.")]
        public string Description { get; set; }
    }
}
