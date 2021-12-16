using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutorial.Repository;
using Tutorial.Models;

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
        public BookController()
        {
            _bookRepository = new BookRepository();
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
        public ViewResult GetAllBooksFromRepository()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        // How to use the parameters.
        // http:domain.com/book/getBook/1
        public string GetBook(int id)
        {
            return $"Book {id}";
        }
        public BookModel GetBookFromRepository(int id)
        {
            return _bookRepository.GetBookById(id);
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
    }
}
