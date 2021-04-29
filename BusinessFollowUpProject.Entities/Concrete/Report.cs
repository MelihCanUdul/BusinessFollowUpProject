using BusinessFollowUpProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Entities.Concrete
{
    public class Report:ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int TaskId { get; set; }
        public Task Tasks { get; set; }
    }
}
