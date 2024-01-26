namespace BookStore.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<StoreBooks> StoreBooks { get; set; } = null!;
    }
}