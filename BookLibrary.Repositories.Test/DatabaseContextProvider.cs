using BookLibrary.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;


namespace BookLibrary.Repositories.Test
{
    internal class DatabaseContextProvider
    {
        public static BookLibraryContext GetDatabaseContextMock()
        {
            var inMemoryContextOptions = new DbContextOptionsBuilder<BookLibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var databaseContextMock = new BookLibraryContextMock(inMemoryContextOptions);

            databaseContextMock.Database.EnsureCreated();

            return databaseContextMock;
        }

    }
}
