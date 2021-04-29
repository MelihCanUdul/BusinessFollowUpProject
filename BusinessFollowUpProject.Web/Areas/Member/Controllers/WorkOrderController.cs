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

namespace BusinessFollowUpProject.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]
    public class WorkOrderController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly INoticeService _noticeService;
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        public WorkOrderController(ITaskService taskService, UserManager<AppUser> userManager, IReportService reportService,INoticeService noticeService)
        {
            _taskService = taskService;
            _userManager = userManager;
            _reportService = reportService;
            _noticeService = noticeService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "workorder";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var tasks = _taskService.GetAllTables(I => I.AppUserId == user.Id && !I.Status);
            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();
            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Urgency = item.Urgency;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.Reports = item.Reports;
                model.CreationDate = item.CreationDate;
                models.Add(model);

            }
            return View(models);
        }
        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "workorder";
            var task = _taskService.GetUrgencyId(id);
            ReportAddViewModel model = new ReportAddViewModel();
            model.TaskId = id;
            model.Tasks = task;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    TaskId = model.TaskId,
                    Detail = model.Detail,
                    Description = model.Definition
                });
                var activeuser = await _userManager.FindByNameAsync(User.Identity.Name);
                var adminlist = await _userManager.GetUsersInRoleAsync("Admin");
                foreach (var admin in adminlist)
                {
                    _noticeService.Save(new Notice
                    {
                        Description=$"{activeuser.Name} {activeuser.SurName} yeni bir rapor yazdı",
                        AppUserId=admin.Id,

                    });
                }


                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "workorder";
            var report = _reportService.GetTaskId(id);
            ReportUpdateViewModel model = new ReportUpdateViewModel();
            model.Id = report.Id;
            model.Definition = report.Description;
            model.Detail = report.Detail;
            model.Tasks = report.Tasks;
            model.TaskId = report.TaskId;
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updatereport = _reportService.GetTaskId(model.Id);
                updatereport.Description = model.Definition;
                updatereport.Detail = model.Detail;
                _reportService.Update(updatereport);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> CompletedTask(int taskId)
        {
            var updatedtask = _taskService.GetId(taskId);
            updatedtask.Status = true;
            _taskService.Update(updatedtask);
            var activeuser = await _userManager.FindByNameAsync(User.Identity.Name);
            var adminlist = await _userManager.GetUsersInRoleAsync("Admin");
            foreach (var admin in adminlist)
            {
                _noticeService.Save(new Notice
                {
                    Description = $"{activeuser.Name} {activeuser.SurName} vermiş olduğunuz bir görevi tamamladı.",
                    AppUserId = admin.Id,

                });
            }
            return Json(null);
        }
    }
}
