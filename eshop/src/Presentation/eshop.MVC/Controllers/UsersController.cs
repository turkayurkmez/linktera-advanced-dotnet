using eshop.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string? gidilecekSayfa, UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                if (userLogin.UserName == "admin" && userLogin.Password == "123")
                {
                    User user = new()
                    {
                        Email = "admin@host.com",
                        Role = "Standard",
                        UserName = "turkay"
                    };
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role,user.Role)

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        Redirect(gidilecekSayfa);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("login", "kullanıcı adı veya şifre yanlış!");

            }
            return View();
        }

        public IActionResult GetUser()
        {
            return Json(User);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }

    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
