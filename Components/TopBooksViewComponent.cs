using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tutorial.Components
{
    // View components are similar to partial views
    // but they don't use model binding and only
    // depend on the data provided when calling into it.
    // They are not being the part of HTTP life cycle.
    // They can be used to create dynamic navigation menu.
    // To get some related data for a page, posts, books etc.
    // To be able to create a shopping cart.
    // Content visible on side of the page.
    // Generally they are under a seperate folder.
    // /Views/{Controller}/Components/{View Component}/{View}
    // /Views/Shared/{Controller}/Components/{View Component}/{View}
    // /Pages/Shared/{Controller}/Components/{View Component}/{View}
    public class TopBooksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
