

namespace BookStore.Dtos
{
    public class BookCreationDto :BookDto
    {
        public int Author { get; set; }
        public int StoreId { get; set; }
    }
}