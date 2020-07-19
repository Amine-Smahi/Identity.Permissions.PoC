using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PermissionsAuth.Enum;
using System.Linq;

namespace PermissionsAuth.Models
{
    public class HasPermissionForAction : AuthorizeAttribute, IAuthorizationFilter
    {
        public Permissions Permission { get; set; }
        public Entities Entity { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(Permission.ToString()) || string.IsNullOrEmpty(Entity.ToString()))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userName = context.HttpContext.User.Identity.Name;
            bool HasPermission = context.HttpContext.User.Identities.First().Claims.Any(x =>
                x.Type == Permission.ToString() &&
                x.Value == Entity.ToString());


            if (HasPermission)
            {
                return;
            }
            context.Result = new ForbidResult();
            return;
        }
    }
}
