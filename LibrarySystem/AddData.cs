using LibrarySystem.Data; 
using LibrarySystem.Models; 
using Microsoft.EntityFrameworkCore;


public class AddData
{
    public static void Run()
    {
        
        using (var context = new LibraryContext())
        {
            var transaction = context.Database.BeginTransaction(); //Starta transaktion
            try
            {
                
                var book = new Book { Title = "I Don't Want To Grow Up", Author = "Scott Stillma", Publication_Date = 2021, Genre = "Rock", Pages = 184, ISBN = 978-1-7323522-6-1};
                context.Books.Add(book);
                var author = new Author { Name = "Scott Stillma", Birth_Date = 1980};
                context.Authors.Add(author);

                var book1 = new Book { Title = "The Pull Of The Stars", Author = "Emma Donoghue", Publication_Date = 2020, Genre = "Fiction", Pages = 256, ISBN = 978-0-316-49901-9};
                var author1 = new Author { Name = "Emma Donoghue", Birth_Date = 1969};
                context.Books.Add(book1);

                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Om något går fel, rulla tillbaka transaktionen
                Console.WriteLine("Ett fel inträffade: " + ex.Message);
            }
            
        }
    }
}