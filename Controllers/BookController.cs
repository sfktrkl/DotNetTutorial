using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutorial.Repository;
using Tutorial.Models;
using System.Dynamic;

namespace Tutorial.Controllers
{
    // A controller is used to group actions (action methods).
    // A controller is used to handle an coming HTTP Request.
    // The mapping of HTTP Request is done using routing.

    // Create a controller when it is needed to define a new
    // group of operations into application.
    // For example for HomeController, it can be created action
    // methods for home page, about page, contacts etc.
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            // Use dependency injection to resolve dependency.
            // It is assigned in Startup.ConfigureServices.
            _bookRepository = bookRepository;
        }

        // All public methods of a controller class are known as Action method.
        // They are created for a specific action in the application.
        // An action method can return several types.
        public IActionResult Index()
        {
            return View();
        }

        // When an we get a HTTP call on controller, we are getting this on
        // a particular action method.
        // http:domain.com/controllerName/actionMethodName
        // http:domain.com/book/getAllBooks (incase-sensitive)
        public string GetAllBooks()
        {
            return "All books";
        }
        public async Task<ViewResult> GetAllBooksFromRepository()
        {
            // If we do not declare @model directive on Views
            // and have a model instance passed to them then
            // we can get the model instance data dynamically
            // on these views and they are called Dynamic views.
            // In these views action method's logic can easily be changed.
            // Also, anonymous data can be passed easily.
            // But it will not be possible getting a compile time error.
            // Hence, it is generally avoided at all.
            dynamic data = new ExpandoObject();
            data.books = await _bookRepository.GetAllBooks();
            return View(data);
        }

        // How to use the parameters.
        // http:domain.com/book/getBook/1
        public string GetBook(int id)
        {
            return $"Book {id}";
        }
        [Route("book-details/{id}", Name = "bookDetails")]
        public async Task<ViewResult> GetBookFromRepository(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        // How to use multiple parameters.
        // http:domain.com/book/searchBooks?bookName=book&authorName=god
        public string SearchBooks(string bookName, string authorName)
        {
            return $"Book name {bookName} & Author name {authorName}";
        }
        public List<BookModel> SearchBooksInRepository(string title, string authorName)
        {
            return _bookRepository.SearchBook(title, authorName);
        }
        private List<string> GetCategories()
        {
            return new List<string>() { 
                "Horror", "Education", "Fantasy" 
            };
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            // Form is used to get data from user.
            // A form has various input options for user,
            // Text box, text area, radio button, checkbox etc.
            // Its components:
            // form tag, input elements, method
            // submit url, submit button
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            // To set some default values to the form.
            var book = new BookModel();
            book.Description = "Some description";

            // Create the select list which will be used
            // for the category dropdown.
            // Instead of creating the select list here
            // it can also be set in the view.
            ViewBag.Category = new SelectList(GetCategories(), "Education"); 

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            // Check the input of the user.
            if (!ModelState.IsValid)
            {
                ViewBag.IsSuccess = false;
                ViewBag.BookId = 0;

                // Validation summary tag helper is used to
                // display a summary of validation messages.
                // To display validation summary, asp-validation-summary
                // All - Property and model validation messages
                // ModelOnly - Only the model validation messages
                // None - No message will be shown
                ModelState.AddModelError("", "This is a model validation message.");
                ViewBag.Category = new SelectList(GetCategories(), "Education"); 
                return View();
            }
            // To handle the post request coming from
            // the form, this action method is needed.
            // It is not needed to set a new action to
            // form element since the action method
            // name has the same view.
            // If contoller is different use asp-action
            int id = await _bookRepository.AddNewBook(bookModel);
            // When the form is submitted and view is returned
            // the last request will be the post request. Hence,
            // when page is refreshed it will be redo the same
            // request. Hence, instead of returning the view
            // return a new form with RedirectToAction.
            // Also, use a return type as IActionResult
            // so that action method can return any type.
            if (id > 0)
                // Set isSuccess parameter so that the alert can be seen
                // when the post request is succeeded.
                // Also set the bookId so the details can be seen.
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            return View();
        }
    }
}
