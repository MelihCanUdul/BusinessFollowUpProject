using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Interfaces
{
    public interface ITask: IGeneric<Task>
    {
        List<Task> GetByUrgencyInComplete();
        List<Task> GetAllTables();
        List<Task> GetAllTables(Expression<Func<Task,bool>>filter);
        List<Task> GetAllTablesInCompleted(out int totalPage,int userId,int activePage);
        Task GetUrgencyId(int id);
        List<Task> GetAppUserId(int appUserId);
        Task GetReportId(int id);
        int GetTaskCountCompletedbyAppUserId(int id);
        int GetTaskCountCompletedAppUserId(int id);
        int AssignWaitTaskCount();
        int GetTaskCompleted();
    }
}
