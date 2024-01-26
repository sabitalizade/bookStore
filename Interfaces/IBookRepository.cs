using BookStore.Models;
using BookStore.Dto;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBook(string title);
        bool BookExists(int id);
        bool CreateBook(Book book, int authorId, int storeId);
        bool DeleteBook(Book book);

        ICollection<Stores> GetStoresByBook(int id);
        bool Save();

    }
}