using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        // The index action method
        public ViewResult Index()
        {
            // If name of the view is same with the action method
            // just call the view, otherwise pass the view name.
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }
    }
}