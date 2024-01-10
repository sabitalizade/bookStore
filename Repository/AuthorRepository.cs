using BooksApi.Data;
using BooksApi.Interfaces;
using BooksApi.Models;

namespace BooksApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;

        }

        public bool AuthorExists(int id)
        {
            bool value = _context.Author.Any(a => a.Id == id);
            return value;
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Author.OrderBy(a => a.Id).ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int id)
        {
            return _context.Books.Where(a => a.Author.Id == id).ToList();
        }
    }
}