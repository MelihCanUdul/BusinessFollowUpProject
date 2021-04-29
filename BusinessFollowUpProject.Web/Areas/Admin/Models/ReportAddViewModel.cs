using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace BusinessFollowUpProject.Web.Areas.Admin.Models
{
    public class ReportAddViewModel
    {
        [Display(Name = "Tanım : ")]
        [Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Definition { get; set; }
        [Display(Name = "Detay : ")]
        [Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Detail { get; set; }
        public Task Tasks { get; set; }
        public int TaskId { get; set; }

    }
}
