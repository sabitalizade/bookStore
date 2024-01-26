using BookStore.Data;
using BookStore.Models;
using Bookshop.Interfaces;

namespace Bookshop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public Users GetCurrent(int id)
        {
            return _context.Users.Find(id);
        }

        public bool Register(Users user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}