using BooksApi.Models;
using BookStore.Dtos;

namespace BooksApi.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBook(string title);
        bool BookExists(int id);
        bool CreateBook(Book book, int authorId, int storeId);
        ICollection<Stores> GetStoresByBook(int id);
        bool Save();

    }
}