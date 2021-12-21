using Microsoft.EntityFrameworkCore;

namespace Tutorial.Data
{
    // In order to work/interact with a database
    // a middle service Entity Framework core is used.
    // EF core can work with, SQL, MySQL, Cosmos db. etc.
    // It is work with object relational mapper O/RM.
    // Database tables converted to Classes
    // Columns converted to Properties
    // To generate databases code first or database first
    // approach can be used.
    // The global package is Microsoft.EntityFrameworkCore
    // For SQL Server,
    // Microsoft.EntityFrameworkCore.Relational
    // Microsoft.EntityFrameworkCore.SqlServer (installs above)
    // Microsoft.EntityFrameworkCore.Tools is needed.
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Extension> Extension { get; set; }

        // To connect with a database use this method.
        // Otherwise pass the option stream during Startup.ConfigureServices.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Since the server will be local it is used as "."
            // Otherwise give the IP address.
            optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
