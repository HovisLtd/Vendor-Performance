using Hovis.Web.Base.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hovis.Web.Base
{
    public partial class IdentityConfig
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/authentication/Index"),
                LogoutPath = new PathString("/authentication/logout"),
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            //{
            //    ClientId = "745758001127-84v8k3eetk0c8df56f5u6oj4rk3atnbu.apps.googleusercontent.com",
            //    ClientSecret = "efATD24XoTZQPilgAmSGhis6",
            //});
            //{
            //    ClientId = "732945296892-vffm4f3p3smp7uhvnqbte3chi60n5k9i.apps.googleusercontent.com",
            //    ClientSecret = "One1Moj9ilc-28YhsbUajS2l",
            //});
            var gProvider = new GoogleOAuth2AuthenticationProvider() { OnAuthenticated = context => Task.FromResult(0) };
            //var gOptions = new GoogleOAuth2AuthenticationOptions()
            //{
            //    Provider = gProvider,
            //    SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
            //    AuthenticationMode = AuthenticationMode.Active,
            //    ClientId = "688730885638-81v1vbdefcvmt5de8qou068k2oiqiqiq.apps.googleusercontent.com",
            //    ClientSecret = "EY3IkJiJ2_oBsklPEublMJDe"
            //};
            var gOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "688730885638-81v1vbdefcvmt5de8qou068k2oiqiqiq.apps.googleusercontent.com",
                ClientSecret = "EY3IkJiJ2_oBsklPEublMJDe",
                Provider = gProvider
            };
            gOptions.Scope.Add("email");
            app.UseGoogleAuthentication(gOptions);
         }
    }
}