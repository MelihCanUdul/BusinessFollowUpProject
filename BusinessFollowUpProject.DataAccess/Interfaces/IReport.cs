using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Interfaces
{
    public interface IReport : IGeneric<Report>
    {
        Report GetTaskId(int id);
        int GetReportCountAppUserId(int id);
        int GetReportCount();
    }
}
