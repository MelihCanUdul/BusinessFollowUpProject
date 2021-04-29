using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    [Area("Admin")]
    public class NoticeController : Controller
    {
        private readonly INoticeService _noticeService;
        private readonly UserManager<AppUser> _userManager;
        public NoticeController(INoticeService noticeService, UserManager<AppUser> userManager)
        {
            _noticeService = noticeService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notice";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var notices = _noticeService.GetUnreads(user.Id);
            List<NoticeListViewModel> models = new List<NoticeListViewModel>();

            foreach (var item in notices)
            {
                NoticeListViewModel model = new NoticeListViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                models.Add(model);
            }
            return View(models);
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var updatedNotice = _noticeService.GetId(id);
            updatedNotice.Status = true;
            _noticeService.Update(updatedNotice);
            return RedirectToAction("Index");

        }
    }
}
