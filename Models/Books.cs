namespace BooksApi.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }
        public int? Price { get; set; }
        public Author Author { get; set; }
        public ICollection<StoreBooks> StoreBooks { get; set; }
    }
}
