using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Areas.Admin.Controllers
{
    // Define the name of the area
    [Area("admin")]
    // Enable the routing
    [Route("admin")]
    // Authorize the action method according to the
    // role. It is possible assigning this to a controller,
    // action methods or globally in startup.
    [Authorize(Roles = "Admin")]
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
