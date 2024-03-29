using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        bool AuthorExists(int id);
        Author GetAuthor(int id);
        Author GetAuthor(string FirstName, string LastName);

        ICollection<Book> GetBooksByAuthor(int id);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
    }
}