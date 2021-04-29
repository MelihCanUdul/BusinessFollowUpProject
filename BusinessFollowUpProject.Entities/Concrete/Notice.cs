using BusinessFollowUpProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Entities.Concrete
{
    public class Notice : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
