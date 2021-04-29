﻿using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Interfaces
{
    public interface INoticeService :IGenericService<Notice>
    {
        int GetUnReadNoticeCountAppUserId(int AppUserId);
        List<Notice> GetUnreads(int AppUserId);
    }
}
