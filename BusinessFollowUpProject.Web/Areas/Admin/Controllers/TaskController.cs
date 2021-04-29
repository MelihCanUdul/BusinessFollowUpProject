using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUrgencyService _urgencyService;
        public TaskController(ITaskService taskService, IUrgencyService urgencyService)
        {
            _taskService = taskService;
            _urgencyService = urgencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "task";
            List<Task> tasks = _taskService.GetByUrgencyInComplete();
            List<TaskListViewModel> models = new List<TaskListViewModel>();
            foreach (var item in tasks)
            {
                TaskListViewModel model = new TaskListViewModel
                {
                    Description = item.Description,
                    Urgency = item.Urgency,
                    UrgencyId = item.UrgencyId,
                    Name = item.Name,
                    Status = item.Status,
                    Id = item.Id,
                    CreationDate = item.CreationDate
                };
                models.Add(model);
            }

            return View(models);
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = "task";

            ViewBag.Urgencys = new SelectList(_urgencyService.GetAll(), "Id", "Description");


            return View(new TaskAddViewModel());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            TempData["Active"] = "task";
            if (ModelState.IsValid)
            {
                _taskService.Save(new Task
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateTask(int id)
        {
            var task = _taskService.GetId(id);
            TaskUpdateViewModel model = new TaskUpdateViewModel
            {
                Id = task.Id,
                Description = task.Description,
                UrgencyId = task.UrgencyId,
                Name = task.Name
            };
            ViewBag.Urgencys = new SelectList(_urgencyService.GetAll(), "Id", "Description", task.UrgencyId);
            return View(model);

        }
        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateViewModel model)
        {
            TempData["Active"] = "task";
            if (ModelState.IsValid)
            {
                _taskService.Update(new Task
                {
                    Id = model.Id,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId,
                    Name = model.Name

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task { Id = id });
            return Json(null);
        }
    }
}
