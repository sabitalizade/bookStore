using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Dto;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
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

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }
        public bool CreateBook(Book book, int authorId, int storeId)
        {
            var Author = _context.Author.Where(a => a.Id == authorId).FirstOrDefault();

            var Store = _context.Stores.Where(s => s.Id == storeId).FirstOrDefault();

            book.Author = Author;
            var storeBook = new StoreBooks
            {
                Books = book,
                Stores = Store
            };


            _context.Add(storeBook);
            _context.Add(book);

            return Save();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).Include(a => a.Author).FirstOrDefault();
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

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}