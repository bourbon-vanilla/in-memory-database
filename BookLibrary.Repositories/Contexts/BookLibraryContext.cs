using BookLibrary.Repositories.Entities;

using Microsoft.EntityFrameworkCore;


namespace BookLibrary.Repositories.Context
{
    internal class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {

        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

    }
}
