using Microsoft.AspNetCore.Mvc;
using Tutorial.Models;
using System.Dynamic;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        // This property will be created as ViewData.
        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string CustomTitle { get; set; }

        [ViewData]
        public BookModel CustomBook { get; set; }

        // The index action method
        public ViewResult Index()
        {
            // ViewBag is used to pass data from action method
            // to view and we can display this data on view.
            // This type of data binding is known as loosely binding.
            // It is possible passing any type of data in ViewBag.
            // To sent multiple data on a view ViewBag is the easiest
            // solution but since it works on a dynamic type it will
            // not give any compile time error.
            ViewBag.Title = 123;
            // It is possible assigning an anonymous data.
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Nitish";
            ViewBag.Data = data;

            // It is possible assigning an object.
            ViewBag.Type = new BookModel() { Id=7, Author="Safak" };

            // ViewData is used to pass data from an action
            // method to a view and can be displayed in view.
            // This type of data binding is known as loosely binding.
            // It doesn't work with dynamic types, it uses key value pairs.
            ViewData["name"] = "Selman";
            ViewData["book"] = new BookModel() { Id=8, Author="Necati" };

            // ViewData Attribute is very similar to ViewData
            // except how they are used.
            CustomProperty = "Custom value";
            CustomTitle = "Welcome to the tutorial";
            CustomBook = new BookModel() { Id=9, Author="Hazal" };

            // If name of the view is same with the action method
            // just call the view, otherwise pass the view name.
            return View();
        }

        public ViewResult Welcome()
        {
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