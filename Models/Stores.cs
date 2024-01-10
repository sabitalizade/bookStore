namespace BooksApi.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StoreBooks> StoreBooks { get; set; }
    }
}