using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly INoticeService _noticeService;
        public WorkOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService, INoticeService noticeService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
            _fileService = fileService;
            _noticeService = noticeService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "workorder";
            //var model = _appUserService.GetNonAdmins();
            List<Task> tasks = _taskService.GetAllTables();
            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();
            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Urgency = item.Urgency;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.CreationDate = item.CreationDate;
                model.Reports = item.Reports;
                models.Add(model);
            }
            return View(models);

        }
        public IActionResult GetExcel(int id)
        {
            return File(_fileService.TransferExcel(_taskService.GetReportId(id).Reports), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }
        public IActionResult GetPdf(int id)
        {
            var path = _fileService.TransferPdf(_taskService.GetReportId(id).Reports);
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
        //Personel listeleme işlemi
        public IActionResult AssignPersonel(int id, string s, int page = 1)
        {
            TempData["Active"] = "workorder";
            ViewBag.Activepage = page;
            ViewBag.Search = s;
            int totalpage;
            var task = _taskService.GetUrgencyId(id);
            var personels = _appUserService.GetNonAdmins(out totalpage, s, page);
            ViewBag.Totalpage = totalpage;
            //ViewBag.Totalpage =(int)Math.Ceiling((double) _appUserService.GetNonAdmins().Count/3);
            List<AppUserListViewModel> appUserListViewModel = new List<AppUserListViewModel>();
            foreach (var item in personels)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Surname = item.SurName;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListViewModel.Add(model);
            }
            ViewBag.Personels = appUserListViewModel;
            TaskListViewModel taskmodel = new TaskListViewModel();
            taskmodel.Id = task.Id;
            taskmodel.Name = task.Name;
            taskmodel.Description = task.Description;
            taskmodel.Urgency = task.Urgency;
            taskmodel.CreationDate = task.CreationDate;

            return View(taskmodel);
        }
        [HttpPost]
        public IActionResult AssignPersonel(PersonelTaskViewModel model)
        {
            var updatetask = _taskService.GetId(model.TaskId);
            updatetask.AppUserId = model.PersonelId;
            
            _taskService.Update(updatetask);
            _noticeService.Save(new Notice
            {
                AppUserId = model.PersonelId,
                Description=$"{updatetask.Name} adlı iş için görevlendirildiniz."

            });
            return RedirectToAction("Index");
        }
        //Personel görevlendirme işlemi 
        public IActionResult PersonelAssign(PersonelTaskViewModel model)
        {
            TempData["Active"] = "workorder";
            var user = _userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId);
            var task = _taskService.GetUrgencyId(model.TaskId);
            AppUserListViewModel usermodel = new AppUserListViewModel();
            usermodel.Id = user.Id;
            usermodel.Name = user.Name;
            usermodel.Picture = user.Picture;
            usermodel.Surname = user.SurName;
            usermodel.Email = user.Email;
            TaskListViewModel taskmodel = new TaskListViewModel();
            taskmodel.Id = task.Id;
            taskmodel.Name = task.Name;
            taskmodel.Urgency = task.Urgency;
            taskmodel.Description = task.Description;
            PersonelTaskListViewModel personelmodel = new PersonelTaskListViewModel();
            personelmodel.AppUser = usermodel;
            personelmodel.Task = taskmodel;
            return View(personelmodel);
        }
        public IActionResult Detail(int id)
        {
            TempData["Active"] = "workorder";
            var task = _taskService.GetReportId(id);
            TaskListAllViewModel model = new TaskListAllViewModel();
            model.Id = task.Id;
            model.Reports = task.Reports;
            model.Name = task.Name;
            model.Description = task.Description;
            model.AppUser = task.AppUser;

            return View(model);
        }
    }
}
