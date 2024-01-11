using BooksApi.Models;

namespace BookStore.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }
        public int? Price { get; set; }
        public AuthorDto Author { get; set; }
    }
}