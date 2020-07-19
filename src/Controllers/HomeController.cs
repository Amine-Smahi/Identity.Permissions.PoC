using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermissionsAuth.Enum;
using PermissionsAuth.Models;
using System.Diagnostics;

namespace PermissionsAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HasPermissionForAction(Permission = Permissions.CanRead, Entity = Entities.Privacy)]
        public IActionResult Privacy()
        {
            return View();
        }

        [HasPermissionForAction(Permission = Permissions.CanRead, Entity = Entities.About)]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
