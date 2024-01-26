namespace BookStore.Models
{

    public class StoreBooks
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int BookId { get; set; }

        public Stores Stores { get; set; }= null!;
        public Book Books { get; set; }= null!;
    }
}