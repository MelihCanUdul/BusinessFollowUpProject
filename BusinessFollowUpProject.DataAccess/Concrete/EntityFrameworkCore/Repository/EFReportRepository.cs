using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{

    public class EFReportRepository : EFGenericRepository<Report>, IReport
    {
        public int GetReportCount()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Reports.Count();
        }

        public int GetReportCountAppUserId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            var result=context.Tasks.Include(I => I.Reports).Where(I => I.AppUserId == id);
            return result.SelectMany(I => I.Reports).Count();
        }

        public Report GetTaskId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Reports.Include(I => I.Tasks).ThenInclude(I=>I.Urgency).Where(I => I.Id == id).FirstOrDefault();

        }
    }
}
