using BooksApi.Models;

namespace BooksApi.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        bool AuthorExists(int id);
        Author GetAuthor(int id);
        ICollection<Book> GetBooksByAuthor(int id);
    }
}