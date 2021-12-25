using System.Collections.Generic;
using System;

namespace Tutorial.Data
{
    // To make the logic separated instead of using model
    // this class is created.
    // Models and entity classes should be separate.
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Keyword { get; set; }
        public int TotalPages { get; set; }

        public string CoverPhotoUrl { get; set; }

        // The table should also be provided.
        // The name of the table is important,
        // it is better matching the name of the table
        // and the Id.
        public int ExtensionId { get; set; }
        public Extension Extension { get; set; }

        public ICollection<Gallery> Gallery { get; set; }

        // From package manager console,
        // Use Add-Migration command to create a table.
        // Created class contains two methods,
        // Up method is used to put data.
        // Down method is used to remove data.
        // Then update the database.
        // Update-Database
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
