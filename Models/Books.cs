namespace BookStore.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }= null!;
        public string? Genre { get; set; }
        public int? Price { get; set; }
        public Author Author { get; set; }= null!;
        public ICollection<StoreBooks> StoreBooks { get; set; }= null!;
    }
}
