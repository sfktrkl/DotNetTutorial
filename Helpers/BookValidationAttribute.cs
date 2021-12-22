using System.ComponentModel.DataAnnotations;

namespace Tutorial.Helpers
{
    public class BookValidationAttribute : ValidationAttribute
    {
        // To make the field required add a constructor which expects
        // the value of the field.
        public BookValidationAttribute(string text)
        {
            Text = text;
        }

        // It is possible making this private since it is 
        // directly assigned through the constructor.
        private string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // User can arrange the ErrorMessage by setting its field.
            if (value == null)
                return new ValidationResult(ErrorMessage ?? "Value is empty.");

            // It is possible using a field to make requirement dynamic.
            // It is also possible creating multiple fields.
            string bookName = value.ToString();
            if (bookName.Contains(Text))
                return new ValidationResult(ErrorMessage ?? "Book name should not contain " + Text);

            return ValidationResult.Success;
        }
    }
}
