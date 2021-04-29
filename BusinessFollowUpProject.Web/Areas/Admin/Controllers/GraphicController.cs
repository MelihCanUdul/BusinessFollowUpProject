using BusinessFollowUpProject.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class GraphicController : Controller
    {

        private readonly IAppUserService _appUserService;
        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        
        public IActionResult Index()
        {
            TempData["Active"] = "graphic";
            return View();
        }
        public IActionResult TaskMostCompleted()
        {
            var jsonString=JsonConvert.SerializeObject(_appUserService.MostTaskCompleted());
            return Json(jsonString);
        }
        public IActionResult TaskMostWorkCompleted()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.MostWorkTaskCompleted());
            return Json(jsonString);
        }
    }
}
