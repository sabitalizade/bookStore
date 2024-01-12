using BookStore.Dtos;

namespace BookStore.Interfaces
{
    public class BookCreation : BookDto
    {
        public int Author { get; set; }
        public int Store { get; set; }
    }
}