using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
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

        public bool CreateAuthor(Author author)
        {
            _context.Author.Add(author);
            return Save();
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.Where(a => a.Id == id).Include(a => a.Books).FirstOrDefault();
        }



        public Author GetAuthor(string FirstName, string LastName)
        {
            return _context.Author.Where(a => a.FirstName == FirstName && a.LastName == LastName).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Author.OrderBy(a => a.Id).Include(a => a.Books).ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int id)
        {
            return _context.Books.Where(a => a.Author.Id == id).ToList();
        }

        public bool UpdateAuthor(Author author)
        {
            _context.Update(author);
            return Save();
        }



        public bool Save()
        {
            var save = _context.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);
            return Save();
        }
    }
}