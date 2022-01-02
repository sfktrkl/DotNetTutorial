using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Areas.Admin.Controllers
{
    // Define the name of the area
    [Area("admin")]
    // Enable the routing
    [Route("admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        [Route("details/{id?}")]
        public ActionResult Details(int id)
        {
            return View(id);
        }
    }
}
