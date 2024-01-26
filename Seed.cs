

using BookStore.Data;
using BookStore.Models;

namespace BookStore
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.StoreBooks.Any())
            {
                var storeBooks = new List<StoreBooks>()
                {
                    new StoreBooks()
                    {

                        Books = new Book()
                        {
                            Title = "The Way of Kings",
                            Genre = "Fantasy",
                            Price = 10,
                            Author = new Author()
                            {
                                FirstName = "Brandon",
                                LastName = "Sanderson"
                            }
                        },
                        Stores = new Stores()
                        {
                            Name = "Amazon"
                        }
                    },
                };
                dataContext.StoreBooks.AddRange(storeBooks);
                dataContext.SaveChanges();
            }
        }
    }
}