﻿using BookLibrary.Repositories.Context;
using BookLibrary.Repositories.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookLibrary.Repositories.Services
{
    internal class AuthorRepository : IAuthorRepository, IDisposable
    {
        private BookLibraryContext _context;


        public AuthorRepository(BookLibraryContext context)
        {
            _context = context;
        }


        public async Task<Author> AddAuthorAsync(string firstName, string lastName)
        {
            return await Task.Factory.StartNew(() => _context.Authors.Add(
                new Author { FirstName = firstName, LastName = lastName }).Entity);
        }

        public async Task<bool> AuthorExistsAsync(Guid authorId)
        {
            return await _context.Authors.AnyAsync(a => a.Id == authorId);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorAsync(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentException(nameof(authorId));
            }

            return await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == authorId); 
        }

        public void UpdateAuthor(Author author)
        {
            // no code in this implementation
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
