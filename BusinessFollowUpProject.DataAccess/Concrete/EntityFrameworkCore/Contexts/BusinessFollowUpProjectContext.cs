using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class BusinessFollowUpProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=sql5104.site4now.net;database=db_a738fe_businessfollowup;User Id=db_a738fe_businessfollowup_admin;Password=melih.2580;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TaskMap());
          
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Urgency> Urgencys { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notice> Notices { get; set; }

    }
}
