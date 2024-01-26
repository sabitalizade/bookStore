using BookStore.Models;

namespace Bookshop.Interfaces
{
    public interface IUserRepository
    {
        Users GetCurrent(int id);
        bool Register(Users user);
        bool Save();
    }

}