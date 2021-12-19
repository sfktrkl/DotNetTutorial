using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Models;
using Tutorial.Data;
using System.Linq;
using System;

namespace Tutorial.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            // If dependency injections are used this
            // dependency will be resolved automatically
            // during Startup.ConfigureServices.
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var book = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            // Using asynchronous calls are important to
            // make application robust and fast. Since, we
            // are working with the databases.
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            // Id will be automatically written to the
            // newly created object (identity specification).
            return book.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            // Get the books from the database and use an
            // async call to do this.
            var data = await _context.Books.ToListAsync();
            var books = new List<BookModel>();
            if (data?.Any() == true)
            {
                foreach (var book in data)
                    books.Add(new BookModel() { 
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Description = book.Description,
                        Language = book.Language,
                        Category = book.Category,
                        TotalPages = book.TotalPages
                    });
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            // Get the book from the database.
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                return new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Language = book.Language,
                    Category = book.Category,
                    TotalPages = book.TotalPages
                };
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Nitish", Description="This is the description for MVC book", Category="Programming", Language="English", TotalPages=134 },
                new BookModel(){Id=2, Title="Dot Net Core", Author="Nitish", Description="This is the description for Dot Net Core book", Category="Framework", Language="Chinese", TotalPages=567 },
                new BookModel(){Id=3, Title="C#", Author="Monika", Description="This is the description for C# book", Category="Developer", Language="Hindi", TotalPages=897 },
                new BookModel(){Id=4, Title="Java", Author="Webgentle", Description="This is the description for Java book", Category="Concept", Language="English", TotalPages=564 },
                new BookModel(){Id=5, Title="Php", Author="Webgentle", Description="This is the description for Php book", Category="Programming", Language="English", TotalPages=100 },
                new BookModel(){Id=6, Title="Azure DevOps", Author="Nitish", Description="This is the description for Azure Devops book", Category="DevOps", Language="English", TotalPages=800 },
            };
        }

    }
}
