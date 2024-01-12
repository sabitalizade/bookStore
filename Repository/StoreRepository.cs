using BooksApi.Data;
using BooksApi.Interfaces;
using BooksApi.Models;

namespace BooksApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;
        public StoreRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooksByStore(int storeId)
        {
            return _context.StoreBooks.Where(s => s.StoreId == storeId).Select(b => b.Books).ToList();
        }

        public Stores GetStore(int storeId)
        {
            return _context.Stores.Where(s => s.Id == storeId).FirstOrDefault();
        }

        public ICollection<Stores> GetStores()
        {
            return _context.Stores.OrderBy(s => s.Id).ToList();
        }

        public bool StoreExists(int storeId)
        {
            return _context.Stores.Any(s => s.Id == storeId);
        }
    }
}