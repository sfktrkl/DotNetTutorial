
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
        public string Title { get; set; }
        public string Author { get; set; }

        public string Description { get; set; }
    }
}
