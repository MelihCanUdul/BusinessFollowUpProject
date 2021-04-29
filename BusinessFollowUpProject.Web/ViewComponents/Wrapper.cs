using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.ViewComponents
{
    public class Wrapper :ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INoticeService _noticeService;
        public Wrapper(UserManager<AppUser> userManager, INoticeService noticeService)
        {
            _noticeService = noticeService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = user.Id;
            model.Picture = user.Picture;
            model.Surname = user.SurName;
            model.Name = user.Name;
            model.Email = user.Email;
            var notices = _noticeService.GetUnreads(user.Id).Count;
            ViewBag.NoticeCount = notices;
            var roles = _userManager.GetRolesAsync(user).Result;
            if(roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
            
           
        }
    }
}
