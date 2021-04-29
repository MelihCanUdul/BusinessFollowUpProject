using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessFollowUpProject.Business.Concrete
{

    public class TaskManager : ITaskService
    {
        private readonly ITask _Itask;
        public TaskManager(ITask Itask)
        {
            _Itask = Itask;
        }

        public int AssignWaitTaskCount()
        {
            return _Itask.AssignWaitTaskCount();
        }

        public void Delete(Task table)
        {
            _Itask.Delete(table);
        }

        public List<Task> GetAll()
        {
            return _Itask.GetAll();
        }

        public List<Task> GetAllTables()
        {
            return _Itask.GetAllTables();
        }

        public List<Task> GetAllTables(Expression<Func<Task, bool>> filter)
        {
            return _Itask.GetAllTables(filter); 
        }

        public List<Task> GetAllTablesInCompleted(out int totalPage, int userId, int activePage)
        {
            return _Itask.GetAllTablesInCompleted(out totalPage, userId, activePage);
        }

        public List<Task> GetAppUserId(int appUserId)
        {
            return _Itask.GetAppUserId(appUserId);
        }

        public List<Task> GetByUrgencyInComplete()
        {
            return _Itask.GetByUrgencyInComplete();
        }

        public Task GetId(int id)
        {
            return _Itask.GetId(id);
        }

        public Task GetReportId(int id)
        {
            return _Itask.GetReportId(id);
        }

        public int GetTaskCompleted()
        {
            return _Itask.GetTaskCompleted();
        }

        public int GetTaskCountCompletedAppUserId(int id)
        {
            return _Itask.GetTaskCountCompletedbyAppUserId(id);
        }

        public int GetTaskCountCompletedbyAppUserId(int id)
        {
            return _Itask.GetTaskCountCompletedbyAppUserId(id);
        }

        public Task GetUrgencyId(int id)
        {
            return _Itask.GetUrgencyId(id);
        }

        public void Save(Task table)
        {
            _Itask.Save(table);
        }

        public void Update(Task table)
        {
            _Itask.Update(table);
        }
    }
}
