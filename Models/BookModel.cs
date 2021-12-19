using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Please enter the number of pages.")]
        [Display(Name = "Total pages of the book")]
        public int? TotalPages { get; set; }
    }
}
