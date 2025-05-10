using Microsoft.AspNetCore.Mvc;
using AcunMedyaTravelProject.Models;
using AcunMedyaTravelProject.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AcunMedyaTravelProject.Controllers
{
    public class LoginController1 : Controller
    {
        private readonly AppDbContext _context;

        public LoginController1(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var checkUser = _context.Admins.FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            if (checkUser != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Username),
            new Claim(ClaimTypes.NameIdentifier, checkUser.Id.ToString()),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                // Kullanıcıyı Dashboard sayfasına yönlendir
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}