using BooksApi.Models;

namespace BooksApi.Interfaces
{
    public interface IStoreRepository
    {
        ICollection<Stores> GetStores();
        Stores GetStore(int storeId);
        bool StoreExists(int storeId);
        bool StoreExists(string name);
        ICollection<Book> GetBooksByStore(int storeId);
        bool CreateStore(Stores store);
        bool UpdateStore(Stores store);
        bool DeleteStore(int storeId);
        bool Save();
    }
}