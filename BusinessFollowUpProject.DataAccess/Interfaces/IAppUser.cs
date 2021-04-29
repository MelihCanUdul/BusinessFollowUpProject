using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Interfaces
{
    public interface IAppUser 
    {
        List<DualHelper> MostTaskCompleted();
        List<DualHelper> MostWorkTaskCompleted();
        List<AppUser> GetNonAdmins();
        List<AppUser> GetNonAdmins(out int totalpage,string searchword, int activepage = 1);
    }
}
