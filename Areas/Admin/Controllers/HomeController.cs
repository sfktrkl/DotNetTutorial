using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Areas.Admin.Controllers
{
    // Define the name of the area
    [Area("admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(id);
        }
    }
}
