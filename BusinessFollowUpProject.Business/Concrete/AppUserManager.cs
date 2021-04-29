using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUser _appUser;
        public AppUserManager(IAppUser appUser)
        {
            _appUser = appUser;
        }
        public List<AppUser> GetNonAdmins()
        {
            return _appUser.GetNonAdmins();
        }

        public List<AppUser> GetNonAdmins(out int totalpage,string searchword, int activepage)
        {
            return _appUser.GetNonAdmins(out totalpage,searchword, activepage);
        }

        public List<DualHelper> MostTaskCompleted()
        {
            return _appUser.MostTaskCompleted();
        }

        public List<DualHelper> MostWorkTaskCompleted()
        {
            return _appUser.MostWorkTaskCompleted();
        }
    }
}
