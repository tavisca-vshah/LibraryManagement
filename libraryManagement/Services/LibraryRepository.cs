using libraryManagement.Entities;
using System;
using System.Linq;

namespace libraryManagement.Services
{
    public class LibraryRepository : ILibraryRepository
    {

        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;

        }
        public IQueryable<Author> GetAuthors()
        {
            var authors =
                _context.Authors
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .AsQueryable();
            return authors;
        }
        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == authorId);
        }
        public void UpdateAuthor(Author author)
        {
            // no code in this implementation
        }
        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }
        public void AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();
            _context.Authors.Add(author);
        }
        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(a => a.Id == authorId);
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
