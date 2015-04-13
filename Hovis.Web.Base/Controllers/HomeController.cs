using System.Threading.Tasks;
using System.Web.Mvc;
using Hovis.Web.Base.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Hovis.Web.Base.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private HovisVPDEntities db = new HovisVPDEntities();

        public async Task<ActionResult> Index()
        {
            var viewModel = new MyViewModel();

            IQueryable<v_HovisVPD_Conformance_Stats_Detail> ConfStats = db.v_HovisVPD_Conformance_Stats_Detail
                .Where(x => x.AllLoged == 1);

            viewModel.OpenCriticalA = ConfStats.Sum(x => x.OpenCritical);
            viewModel.OpenMajorA = ConfStats.Sum(x => x.OpenMajor);
            viewModel.OpenMinorA = ConfStats.Sum(x => x.OpenMinor);
            viewModel.AllCriticalA = ConfStats.Sum(x => x.AllCritical);
            viewModel.AllMajorA = ConfStats.Sum(x => x.AllMajor);
            viewModel.AllMinorA = ConfStats.Sum(x => x.AllMinor);
            viewModel.AllOpenA = ConfStats.Sum(x => x.AllOpen);
            viewModel.AllClosedA = ConfStats.Sum(x => x.AllClosed);
            viewModel.AllLoggedA = ConfStats.Sum(x => x.AllLoged);
            viewModel.OpenLast10daysA = ConfStats.Sum(x => x.OpenedLast10Days);
            viewModel.Closedlast10daysA = ConfStats.Sum(x => x.ClosedLast10Days);
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "About Hovis VPD.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Hovis IS contact details.";

            return View();
        }


    }
}