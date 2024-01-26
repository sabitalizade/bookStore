namespace BookStore.Dto
{
    public class BookCreationDto :BookDto
    {
        public int AuthorId { get; set; }
        public int StoreId { get; set; }
    }
}