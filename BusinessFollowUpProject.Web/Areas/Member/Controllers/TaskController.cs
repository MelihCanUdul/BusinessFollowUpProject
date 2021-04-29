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
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        public TaskController(ITaskService taskService, UserManager<AppUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }



        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = "task";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var tasks = _taskService.GetAllTablesInCompleted(out totalPage, user.Id, activePage);
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();
            foreach (var task in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = task.Id;
                model.Description = task.Description;
                model.Urgency = task.Urgency;
                model.Name = task.Name;
                model.AppUser = task.AppUser;
                model.CreationDate = task.CreationDate;
                model.Reports = task.Reports;
                models.Add(model);
            }
            return View(models);
        }
    }
}
