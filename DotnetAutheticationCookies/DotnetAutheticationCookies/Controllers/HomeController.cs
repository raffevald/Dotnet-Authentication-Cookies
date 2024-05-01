using DotnetAutheticationCookies.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace DotnetAutheticationCookies.Controllers {
    [Authorize]
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController ( ILogger<HomeController> logger ) {
            _logger = logger;
        }

        public IActionResult Index ( ) {
            ClaimsPrincipal claimUser = HttpContext.User;

            return View ();
        }

        public async Task<IActionResult> LogOut ( ) {
            await HttpContext.SignOutAsync ( CookieAuthenticationDefaults.AuthenticationScheme );
            return RedirectToAction ( "Login", "Access" );
        }

        [ResponseCache ( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error ( ) {
            return View ( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}
