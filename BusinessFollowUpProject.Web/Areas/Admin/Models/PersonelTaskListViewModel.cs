using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BusinessFollowUpProject.Web.Areas.Admin.Models
{
    public class PersonelTaskListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public TaskListViewModel Task { get; set; }
    }
}
