using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Interfaces
{
    public interface INotice : IGeneric<Notice>
    {
        List<Notice> GetUnreads(int AppUserId);
        int GetUnReadNoticeCountAppUserId(int AppUserId);

    }
}
