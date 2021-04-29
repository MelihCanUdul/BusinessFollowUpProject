using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NoticeMap : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasColumnType("ntext").IsRequired();
            builder.HasOne(I => I.AppUser).WithMany(I => I.Notices).HasForeignKey(I => I.AppUserId);
        }
    }
}
