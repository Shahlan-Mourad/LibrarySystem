using LibrarySystem.Data; 
using LibrarySystem.Models; 
using Microsoft.EntityFrameworkCore;
using LibrarySystem.ReadData;



namespace LibrarySystem.AddData
{
    public class csAddData
    {
        private readonly LibraryContext _context;
        public csAddData(LibraryContext context)
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

        public void DisplayAdd() // för att lägga en bok eller rigistera en medlem från termialen 
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Välj vad du vill lägga till: ");
                Console.WriteLine("1. Bok");
                Console.WriteLine("2. Medlem");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        AddMember();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                }
            }
        }

        private void AddBook() // för att lägga till en bok
        {
            Console.Write("Ange BokTitel: ");
            var title = Console.ReadLine();
            Console.Write("Ange BokFörfattare: ");
            var author = Console.ReadLine();
            Console.Write("Ange BokGenre: ");
            var genre = Console.ReadLine();
            Console.Write("Ange BokÅr: ");
            var publishedyear = int.Parse(Console.ReadLine());
            Console.Write("Antal Sidor");
            var page  = int.Parse(Console.ReadLine());
            Console.Write("ISBN: ");
            var ISBN = Console.ReadLine();
            // kontrollera om författaren redan finns i databasen
            var _author = _context.Authors.FirstOrDefault(a => a.Name == author);
            if (_author == null)
            {
                _author = new Author { Name = author};
                _context.Authors.Add(_author); // lägg till författaren till tabelen Authors i databasen 
            }

            var book = new Book { Title = title, Author = author, Genre = genre, Publication_Year = publishedyear, Pages = page, ISBN = ISBN };
            _context.Books.Add(book); // lägg till boken till tabelen Books i databasen
            _context.SaveChanges();
            Console.WriteLine($"{title} tilllagd");
        }   
        public void AddMember() // för att rigistera som en medlem
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