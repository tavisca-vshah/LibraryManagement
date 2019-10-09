using System;
using System.Linq;
using libraryManagement.Entities;

namespace libraryManagement.Services
{
    public interface ILibraryRepository
    {
        void AddAuthor(Author author);
        bool AuthorExists(Guid authorId);
        void DeleteAuthor(Author author);
        Author GetAuthor(Guid authorId);
        IQueryable<Author> GetAuthors();
        bool Save();
        void UpdateAuthor(Author author);
    }
}