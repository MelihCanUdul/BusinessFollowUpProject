using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessFollowUpProject.Business.Interfaces
{

    public interface ITaskService : IGenericService<Task>
    {
        int GetTaskCompleted();
        int AssignWaitTaskCount();
        List<Task> GetByUrgencyInComplete();
        List<Task> GetAllTables();
        List<Task> GetAllTables(Expression<Func<Task, bool>> filter);
        Task GetUrgencyId(int id);
        List<Task> GetAppUserId(int appUserId);
        Task GetReportId(int id);
        List<Task> GetAllTablesInCompleted(out int totalPage, int userId, int activePage=1);
        int GetTaskCountCompletedbyAppUserId(int id);
        public int GetTaskCountCompletedAppUserId(int id);
    }
}
