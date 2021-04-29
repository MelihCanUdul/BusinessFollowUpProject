using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetTaskId(int id);
        int GetReportCountAppUserId(int id);
        int GetReportCount();
    }
}
