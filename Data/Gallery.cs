
namespace Tutorial.Data
{
    public class Gallery
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Books Book { get; set; }
    }
}
