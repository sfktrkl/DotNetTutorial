using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Tutorial.Helpers;
using Tutorial.Enums;

namespace Tutorial.Models
{
    // Model is responsible from data.
    // We get/set data from/to source in form of Model.
    public class BookModel
    {
        // This model has three properties, Id, title and Author.
        // We will be getting the data from a particular database.
        // So, a seperate part should be created to create a logic
        // and get the data, like BookRepository.
        public int Id { get; set; }
        // Validation is a process of checking an activity
        // whether it meets the desired level of compliance.
        // In Asp.Net core, validation is the process of
        // checking fields of a form to meet defined criteria.
        // The validations are used as attributes.
        // They are available, System.ComponentModel.DataAnnotations
        // We can validate, set error messages, set display label
        // field type etc. for a particular field.
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the title of the book.")]
        [BookValidation("book", ErrorMessage = "Book name cannot contain 'book'")]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the Author name.")]
        public string Author { get; set; }

        // Only when an input is entered this is requirement
        // will be checked. Since, it is not a required field.
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        // DataType attribute doesn't used to validate the
        // field, but to generate a field on the form.
        [DataType(DataType.Text)]
        [Display(Name = "Book Category")]
        public string Category { get; set; }

        [DataType(DataType.Text)]
        public string Language { get; set; }

        [DataType(DataType.Text)]
        public string Keyword { get; set; }

        public List<string> Keywords { get; set; }

        public TypeEnum Type { get; set; }

        [Display(Name = "Book Extension")]
        public int ExtensionId { get; set; }
        public string Extension { get; set; }

        [Required(ErrorMessage = "Please enter the number of pages.")]
        [Display(Name = "Total pages of the book")]
        public int? TotalPages { get; set; }

        // Since image is an heavy file (blob) instead of 
        // uploading them to the database data should be
        // saved to an other place like Azure blob storage.
        // wwwroot file can be used to store those files for now.
        [Required]
        [Display(Name = "Choose cover photo")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoUrl { get; set; }

        [Required]
        [Display(Name = "Choose images of your book")]
        //public List<IFormFile> GalleryFiles { get; set; }
        //public IEnumerable<IFormFile> GalleryFiles { get; set; }
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }

        [Required]
        [Display(Name = "Choose book file")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
