using BookLibrary.Repositories.Context;
using BookLibrary.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("BookLibrary.Repositories.Test")]


namespace BookLibrary.Repositories
{
    public static class BookLibraryRepositoriesExtensions
    {
        /// <summary>
        /// Microsoft extensions dependency injection service registration method.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="connectionString">Sql database connection string.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddBookLibraryRepositories(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    "Connection string has to be set", nameof(connectionString));

            return services
                .AddDbContext<BookLibraryContext>(optionsBuilder =>
                    optionsBuilder.UseSqlServer(connectionString))
                .AddTransient<IAuthorRepository, AuthorRepository>()
                .AddTransient<IBookRepository, BookRepository>();
        }
    }
}
