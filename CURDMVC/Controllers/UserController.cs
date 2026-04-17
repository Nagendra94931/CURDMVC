using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CURDMVC.Controllers
{
    public class UserController : Controller
    {


        //Home page - open to all users
        public async Task<IActionResult> Index()
        {
            await Task.Delay(1);
            return View();
        }







        #region Login / Logout

        public async Task<IActionResult> Login()
            {
                await Task.Delay(1);
                return  View();
            }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, bool rememberMe)
        {
            if (username == "admin" && password == "123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        //If rememberMe == true user remember
                        IsPersistent = rememberMe, // remember user
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                    });

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid login";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           return RedirectToRoute("Login");
        }



        #endregion


        #region Dashboard

        [Authorize]
            public IActionResult Dashboard()
            {
                return View();
            }

        #endregion














    }
}
