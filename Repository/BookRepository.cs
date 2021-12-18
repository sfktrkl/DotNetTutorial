﻿using System.Collections.Generic;
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

        public int AddNewBook(BookModel model)
        {
            var book = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            // Id will be automatically written to the
            // newly created object (identity specification).
            return book.Id;
        }

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
