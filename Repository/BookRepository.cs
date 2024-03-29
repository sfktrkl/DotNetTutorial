﻿using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Models;
using Tutorial.Data;
using System.Linq;
using System;

namespace Tutorial.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context, IConfiguration configuration)
        {
            // If dependency injections are used this
            // dependency will be resolved automatically
            // during Startup.ConfigureServices.
            _context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var book = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                Category = model.Category,
                Language = model.Language,
                Keyword = model.Keyword,
                ExtensionId = model.ExtensionId,
                CoverPhotoUrl = model.CoverPhotoUrl,
                BookPdfUrl = model.BookPdfUrl,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            book.Gallery = new List<Gallery>();
            foreach (var file in model.Gallery)
            {
                book.Gallery.Add(new Gallery()
                {
                    Name = file.Name,
                    Url = file.Url
                });
            }

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
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    Keyword = book.Keyword,
                    ExtensionId = book.ExtensionId,
                    Extension = book.Extension.Name,
                    CoverPhotoUrl = book.CoverPhotoUrl,
                    TotalPages = book.TotalPages
                }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    Keyword = book.Keyword,
                    ExtensionId = book.ExtensionId,
                    Extension = book.Extension.Name,
                    CoverPhotoUrl = book.CoverPhotoUrl,
                    TotalPages = book.TotalPages
                }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            // Get the book from the database.
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    Keyword = book.Keyword,
                    ExtensionId = book.ExtensionId,
                    Extension = book.Extension.Name,
                    CoverPhotoUrl = book.CoverPhotoUrl,
                    BookPdfUrl = book.BookPdfUrl,
                    Gallery = book.Gallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url
                    }).ToList(),
                    TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();
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

        public string GetAppName()
        {
            return _configuration["AppName"];
        }

    }
}
