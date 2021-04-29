using BusinessFollowUpProject.Entities.Concrete;
using BusinessFollowUpProject.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessFollowUpProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var appuser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appuser.Id;
            model.Name = appuser.Name;
            model.Email = appuser.Email;
            model.Surname = appuser.SurName;
            model.Picture = appuser.Picture;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile img)

        {
            if (ModelState.IsValid)
            {
                var updateuser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (img != null)
                {
                    string path1 = Path.GetExtension(img.FileName);
                    string imgname = Guid.NewGuid() + path1;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imgname);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }
                    updateuser.Picture = imgname;
                }
                updateuser.Name = model.Name;
                updateuser.SurName = model.Surname;
                updateuser.Email = model.Email;
                var result = await _userManager.UpdateAsync(updateuser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme İşleminiz Başarıyla Gerçekleştirildi";
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
    }
}
