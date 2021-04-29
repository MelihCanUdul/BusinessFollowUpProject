using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
      
        private readonly ITaskService _taskService;
        private readonly IReportService _reportService;
        private readonly INoticeService _noticeService;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ITaskService taskService, INoticeService noticeService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _taskService = taskService;
            _noticeService = noticeService;
            _userManager = userManager;
            _reportService = reportService;
         
            
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Active"] = "home";
            ViewBag.AssignTaskCount=_taskService.AssignWaitTaskCount();
            ViewBag.GetTaskCompleted = _taskService.GetTaskCompleted();
            ViewBag.UnReadNoticeCount = _noticeService.GetUnReadNoticeCountAppUserId(user.Id);
            ViewBag.TotalReportCount = _reportService.GetReportCount();
            return View();
        }
       
    }
}
