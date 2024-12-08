using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;

namespace LibrarySystem.SeedData
{
    public static class csSeedData
    {
        public static void SeedData(LibraryContext context)
        {
            if (!context.Books.Any(b => b.Title == "Lev livet fullt ut"))
            {
                var author1 = new Author { Name = "Eckhart Tolle", Birth = 1959 };
                var author2 = new Author { Name = "Napoleon Hill", Birth = 1977 };

                var book1 = new Book {  Title = "Lev livet fullt ut", 
                                        Genre = "Självhjälpslitteratur", 
                                        Pages = 185, 
                                        Publication_Year = 2015, 
                                        ISBN = "978-91-8750554-6", 
                                    };
              

                var book2 = new Book {  Title = "Tänk Rätt bli Framgångsrik", 
                                        Genre = "Action", 
                                        Pages = 358,    
                                        Publication_Year = 2013, 
                                        ISBN = "978-91-9788906-3", 
                                     };
                context.Authors.Add(author1);
                context.Books.Add(book1);
                context.Authors.Add(author2);
                context.Books.Add(book2);

                context.SaveChanges();
            }
        }
    }
}