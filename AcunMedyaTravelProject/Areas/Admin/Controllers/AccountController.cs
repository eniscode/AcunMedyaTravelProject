using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
  
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entities.Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kullanıcı başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Kullanıcı eklenirken bir hata oluştu.";
            return View(admin);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var admin = GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        [HttpPost]
        public IActionResult Edit(Entities.Admin admin)
        {
            if (ModelState.IsValid)
            {
                var existingAdmin = GetAdminById(admin.Id);
                if (existingAdmin == null)
                {
                    return NotFound();
                }

                existingAdmin.UserName = admin.UserName;

                // Şifre boş bırakılmışsa mevcut şifreyi koru
                if (!string.IsNullOrWhiteSpace(admin.Password))
                {
                    existingAdmin.Password = admin.Password;
                }

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kullanıcı başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Kullanıcı güncellenirken bir hata oluştu.";
            return View(admin);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var admin = GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction("Index");
        }

        private Entities.Admin GetAdminById(int id)
        {
            return _context.Admins.FirstOrDefault(a => a.Id == id);
        }
    }
}



