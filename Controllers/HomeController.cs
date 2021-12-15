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

        public ViewResult ContactUs()
        {
            // To return a view from an action method with a model,
            // var obj = new { Id = 1, Name = "Nitish" };
            // return View(modelObj);
            // return View("viewName", modelObj);

            // To return a view from another location,
            // Full path of view or a relative path.
            // return View("Views/Shared/ContactUs.cshtml");

            // Razor View Engine is responsible from this view discovery.

            return View();
        }

        public ViewResult RazorViewEngine()
        {
            // View engine is a piece of code which is used to render
            // server side code into the view.
            // View engines is used to set/get the default path location
            // for views, shared folders etc.
            // Razor view engine is used to write C# logics on the views.
            // In Razor view engine, everything starts with @,
            // It is possible writing single line and multi line syntax.

            return View();
        }

    }
}