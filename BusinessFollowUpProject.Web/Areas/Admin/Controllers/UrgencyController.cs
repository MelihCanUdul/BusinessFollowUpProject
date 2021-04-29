using BusinessFollowUpProject.Business.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;


namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {

        private readonly IUrgencyService _urgencyservice;
        public UrgencyController(IUrgencyService urgencyservice)
        {
            _urgencyservice = urgencyservice;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "urgency";
            List<Urgency> urgencys = _urgencyservice.GetAll();
            List<UrgencyListViewModel> model = new List<UrgencyListViewModel>();

            foreach (var item in urgencys)
            {
                UrgencyListViewModel urgencymodel = new UrgencyListViewModel();
                urgencymodel.Id = item.Id;
                urgencymodel.Description = item.Description;
                model.Add(urgencymodel);

            }
            return View(model);
        }
        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";
            return View(new UrgencyAddViewModel());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyservice.Save(new Urgency()
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = "urgency";

            var urgency = _urgencyservice.GetId(id);
            UrgencyUpdateViewModel model = new UrgencyUpdateViewModel
            {
                Id = urgency.Id,
                Description = urgency.Description
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                _urgencyservice.Update(new Urgency
                {
                    Id = model.Id,
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
