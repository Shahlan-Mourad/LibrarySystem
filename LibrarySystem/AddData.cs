using LibrarySystem.Data; 
using LibrarySystem.Models; 
using Microsoft.EntityFrameworkCore;
using LibrarySystem.ReadData;



namespace LibrarySystem.AddData
{
    

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

        private readonly LibraryContext _context;
        public AddData(LibraryContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddBookAuthor(int book_ID, int author_ID) //om en bok ha flera författare och en författare skrivt flera böcker,
        {
            var bookAuthor = new BookAuthor { BookId = book_ID, AuthorId = author_ID };
            _context.BookAuthors.Add(bookAuthor);
            _context.SaveChanges();
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void DisplayAdd()
        {
            Console.WriteLine("Välj vad du vill lägga till: ");
            Console.WriteLine("1. Bok");
            Console.WriteLine("4. Medlem");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    AddMember();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val");
                    break;
            }
        }

        private void AddBook()
        {
            Console.Write("Ange BokTitel: ");
            var title = Console.ReadLine();
            Console.Write("ISBN: ");
            var ISBN = int.Parse(Console.ReadLine());  

            var book = new Book { Title = title, ISBN = ISBN };
            _context.Books.Add(book);
            _context.SaveChanges();
            Console.WriteLine($"{title} tilllagd");
        }   

        public void AddMember()
        {
            Console.Write("Ange förnamn: ");
            var fristName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            var lastName = Console.ReadLine();
            Console.Write("Ange epost: ");
            var email = Console.ReadLine();

            var member = new Member { FristName = fristName, LastName = lastName, Email = email, MembershipStartDate = DateTime.Now };
            _context.Members.Add(member);
            _context.SaveChanges();
            Console.WriteLine($"Medlem {fristName} {lastName} tillagd");
        }


    }
}