using BooksApi.Models;

namespace BooksApi.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBook(string title);
        bool BookExists(int id);
        ICollection<Stores> GetStoresByBook(int id);

    }
}