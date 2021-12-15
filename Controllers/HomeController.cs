using Microsoft.AspNetCore.Mvc;

namespace Tutorial.Controllers
{
    public class HomeController : Controller
    {
        // The index action method
        public string Index()
        {
            return "Hello from controller.";
        }
    }
}