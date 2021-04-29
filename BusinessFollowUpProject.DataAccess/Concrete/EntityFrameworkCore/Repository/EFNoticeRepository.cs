using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EFNoticeRepository : EFGenericRepository<Notice>, INotice
    {
        public int GetUnReadNoticeCountAppUserId(int AppUserId)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Notices.Count(I => I.AppUserId == AppUserId && !I.Status);
        }

        public List<Notice> GetUnreads(int AppUserId)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Notices.Where(I => I.AppUserId == AppUserId && !I.Status).ToList();
        }
    }
}
