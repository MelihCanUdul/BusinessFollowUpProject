using BusinessFollowUpProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Entities.Concrete
{

    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "user.png";
        public List<Notice> Notices { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
