using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PermissionsAuth.Enum;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PermissionsAuth.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthorizationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            Claim claim = new Claim(Permissions.CanRead.ToString(), Entities.Privacy.ToString());

            var IdentityUser = await _userManager.GetUserAsync(HttpContext.User);

            string role = Roles.Admin.ToString();

            await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(IdentityUser, role);

            var roles = await _userManager.GetRolesAsync(IdentityUser);
            var CurrentUserRole = await _roleManager.FindByNameAsync(roles.First());

            await _roleManager.AddClaimAsync(CurrentUserRole, claim);

            return View();
        }

        public async Task<IActionResult> AddPermission()
        {
            var IdentityUser = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddClaimAsync(
               IdentityUser, new Claim(Permissions.CanRead.ToString(), Entities.About.ToString())
           );
            return Ok("Ok");
        }

        public IActionResult GetPermissions()
        {
            var claims = HttpContext.User.Identities.First().Claims
                .Where(x => x.Type.Contains("Can"))
                .Select(x => x.Type + x.Value).ToList();
            return Json(claims);
        }
    }
}
