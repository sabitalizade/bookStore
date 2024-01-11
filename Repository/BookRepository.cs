using BooksApi.Data;
using BooksApi.Interfaces;
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;

        }

        public bool BookExists(int id)
        {
            bool value = _context.Books.Any(b => b.Id == id);
            return value;
        }


        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBook(string title)
        {
            return _context.Books.Where(b => b.Title == title).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).Include(b => b.Author).ToList();
        }

        public ICollection<Stores> GetStoresByBook(int id)
        {
            return _context.StoreBooks.Where(b => b.BookId == id).Select(s => s.Stores).ToList();
        }
    }
}