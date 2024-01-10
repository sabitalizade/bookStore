using BooksApi.Models;

namespace BooksApi.Interfaces
{
    public interface IStoreRepository
    {
        ICollection<Stores> GetStores();
        Stores GetStore(int storeId);
        ICollection<Book> GetBooksByStore(int storeId);
    }
}