using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;
        public StoreRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateStore(Stores store)
        {
            _context.Add(store);
            return Save();
        }

        public bool DeleteStore(int storeId)
        {
            var store = GetStore(storeId);
            _context.Remove(store);
            return Save();
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

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool StoreExists(int storeId)
        {
            return _context.Stores.Any(s => s.Id == storeId);
        }

        public bool StoreExists(string name)
        {
            return _context.Stores.Any(s => s.Name == name);
        }

        public bool UpdateStore(Stores store)
        {
            _context.Update(store);
            return Save();
        }
    }
}