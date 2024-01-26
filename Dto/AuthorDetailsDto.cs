using BookStore.Models;

namespace BookStore.Dto
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
}