using BooksApi.Models;

namespace BookStore.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
}