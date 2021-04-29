using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Member.Controllers
{

    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly INoticeService _noticeService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INoticeService noticeService)
        {
            _reportService = reportService;
            _userManager = userManager;
            _taskService = taskService;
            _noticeService = noticeService;
        }
        public async Task<IActionResult> Index()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Active"] = "home";
            ViewBag.ReportCount = _reportService.GetReportCountAppUserId(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetTaskCountCompletedbyAppUserId(user.Id);
            ViewBag.NeedCompletedTaskCount = _taskService.GetTaskCountCompletedAppUserId(user.Id);
            ViewBag.UnReadNoticeCount = _noticeService.GetUnReadNoticeCountAppUserId(user.Id);
            return View();
        }
    }
}
