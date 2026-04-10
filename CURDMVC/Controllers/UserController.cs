using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CURDMVC.Controllers
{
    public class UserController : Controller
    {

        #region Login / Logout

            public async Task<IActionResult> Login()
            {
                await Task.Delay(1);
                return  View();
            }


            [HttpPost]
            public async Task<IActionResult> Login(string username, string password)
            {
                // Example validation (replace with DB check)
                if (username == "admin" && password == "123")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    //(Set Expiry for 30 mins)
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,
                    //    new AuthenticationProperties
                    //    {
                    //        IsPersistent = true,
                    //        ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                    //    });

                return RedirectToAction("Index", "Home");
                }

                ViewBag.Error = "Invalid login";
                return View();
            }


            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login");
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
