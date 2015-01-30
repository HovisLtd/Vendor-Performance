using Hovis.Web.Base.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace Hovis.Web.Base
{
    public static partial class IdentityConfig
    {
        //string array with Role Names that will be created for this application on startup
        private static readonly string[] RolesToCreate =
        {
            "Admin"
            //others can be added here
        };

        public static void SeedRoles()
        {
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            //iterate over the array of roles to create
            foreach (var roleToCreate in RolesToCreate)
            {
                //check to see if we already have a role by that name
                var role = roleManager.FindByName(roleToCreate);

                //if we do, move on to the next one, we don't want to create duplicates!
                if (role != null) continue;

                //otherwise, create the role
                roleManager.Create(new IdentityRole(roleToCreate));
            }
        }
    }
}