using BookLibrary.Repositories.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookLibrary.Repositories.Services
{
    public interface IAuthorRepository : IDisposable
    {
        Task<Author> AddAuthorAsync(string firstName, string lastName);

        Task<bool> AuthorExistsAsync(Guid authorId);

        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(Guid authorId);

        void UpdateAuthor(Author author);

        Task<bool> SaveChangesAsync();
    }
}
