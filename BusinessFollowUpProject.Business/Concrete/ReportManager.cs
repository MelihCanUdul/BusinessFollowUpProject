using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Concrete
{
    public class ReportManager : IReportService
    {

       private readonly IReport _report;
        public ReportManager(IReport report)
        {
            _report = report;
        }
        public void Delete(Report table)
        {
            _report.Delete(table);
        }

        public List<Report> GetAll()
        {
            return _report.GetAll();
        }

        public Report GetId(int id)
        {
            return _report.GetId(id);
        }

        public int GetReportCount()
        {
            return _report.GetReportCount();
        }

        public int GetReportCountAppUserId(int id)
        {
            return _report.GetReportCountAppUserId(id);
        }

        public Report GetTaskId(int id)
        {
            return _report.GetTaskId(id);
        }

        public void Save(Report table)
        {
            _report.Save(table);
        }

        public void Update(Report table)
        {
            _report.Update(table);
        }
    }
}
