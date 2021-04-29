using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EFTaskRepository : EFGenericRepository<Task>, ITask
    {
        public int AssignWaitTaskCount()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Count(I => I.AppUserId == null && !I.Status);
        }

        public List<Task> GetAllTables()
        {
            using (var context = new BusinessFollowUpProjectContext())
            {
               
                return context.Tasks.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I => !I.Status).OrderByDescending(I => I.CreationDate).ToList();
            }
        }

        public List<Task> GetAllTables(Expression<Func<Task, bool>> filter)
        {
            using (var context = new BusinessFollowUpProjectContext())
            {

                return context.Tasks.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(filter).OrderByDescending(I => I.CreationDate).ToList();
            }
        }

        public List<Task> GetAllTablesInCompleted(out int totalPage, int userId,int activePage=1)
        {
            using (var context = new BusinessFollowUpProjectContext())
            {
                var returnvalue = context.Tasks.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I => I.AppUserId == userId && I.Status).OrderByDescending(I => I.CreationDate);
                totalPage = (int)Math.Ceiling((double)returnvalue.Count()/3);
                return returnvalue.Skip((activePage - 1) * 3).Take(3).ToList();
            }

        }

        public List<Task> GetAppUserId(int appUserId)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Where(I => I.AppUserId == appUserId).ToList();
        }

        public List<Task> GetByUrgencyInComplete()
        {
            using (var context = new BusinessFollowUpProjectContext())
            {
                return context.Tasks.Include(I => I.Urgency).
                    Where(I => !I.Status).OrderByDescending(I => I.CreationDate).ToList();

            }
        }
        public Task GetReportId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Include(I => I.Reports).Include(I=>I.AppUser).Where(I => I.Id == id).FirstOrDefault();

        }

        public int GetTaskCompleted()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Count(I => I.Status);
        }

        //TAMAMLANMAYAN İŞLER
        public int GetTaskCountCompletedAppUserId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Count(I => I.AppUserId == id && !I.Status);
        }
        //TAMAMLANAN İŞLER
        public int GetTaskCountCompletedbyAppUserId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Count(I => I.AppUserId == id && I.Status);
        }

        public Task GetUrgencyId(int id)
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Include(I=>I.Urgency).FirstOrDefault(I=>!I.Status && I.Id==id);
        }
    }
}
