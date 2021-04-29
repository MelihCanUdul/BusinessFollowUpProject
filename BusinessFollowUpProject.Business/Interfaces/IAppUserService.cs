using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNonAdmins();
        List<AppUser> GetNonAdmins(out int totalpage, string searchword, int activepage = 1);
        List<DualHelper> MostWorkTaskCompleted();
        List<DualHelper> MostTaskCompleted();
    }
}
