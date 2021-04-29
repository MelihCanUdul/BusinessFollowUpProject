﻿using BusinessFollowUpProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Entities.Concrete
{
    public class Task : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }

    }
}
