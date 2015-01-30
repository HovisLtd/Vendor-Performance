using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hovis.Web.Base.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreatedDate = DateTime.Now;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get { return string.Join(" ", FirstName, LastName); } }

        public DateTime CreatedDate { get; set; }
    }
}