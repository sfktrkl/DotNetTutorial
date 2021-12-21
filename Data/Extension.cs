using System.Collections.Generic;

namespace Tutorial.Data
{
    public class Extension
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // To be able to use the Books table, provide it.
        public ICollection<Books> Books { get; set; }
    }
}
