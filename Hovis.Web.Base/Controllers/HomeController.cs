using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hovis.Web.Base.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}