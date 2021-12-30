using ClientFrontEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClientFrontEnd.Controllers
{
    public class AuthController : Controller
    {
        ApiService apiService = new ApiService();
        public IActionResult Login()
        {
            apiService.logout();
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
