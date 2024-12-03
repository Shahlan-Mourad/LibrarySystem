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
                Console.WriteLine("Välj ett alternativ: \n\n");
                Console.WriteLine("1. Add Bok");
                Console.WriteLine("2. Låna Bok");
                Console.WriteLine("3. Returnera Bok");
                Console.WriteLine("4. Ta bort Bok");
                Console.WriteLine("5. Medlem");
                Console.WriteLine("6. Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        AddLoan();
                        break;
                    case "3":
                        ReturnBook();
                        break;
                    case "4":
                        RemoveBook();
                        break;
                    case "5":
                        AddMember();
                        break;
                    case "6":
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

        private void AddLoan()
        {
            Console.Write("Ange MedlemsID: ");
            var memberid = int.Parse(Console.ReadLine());
            Console.Write("Ange BokID: ");
            var bookid = int.Parse(Console.ReadLine());

            var _member = _context.Members.FirstOrDefault(m => m.MemberID == memberid);
            if (_member == null) // om medlemmen inte finns i databasen
            {
                Console.WriteLine("Medlem inte hittad");
                return;
            }

            var _book = _context.Books.FirstOrDefault(b => b.BookID == bookid);
            if (_book == null) // om boken inte finns i databasen
            {
                Console.WriteLine("Bok inte hittad");
                return;
            }

            var loan = new Loan { MemberID = memberid, BookID = bookid, LoanDate = DateTime.Now, ReturnDate = DateTime.Now.AddMonths(1)};
            _context.Loans.Add(loan);
            _context.SaveChanges();
            Console.WriteLine($"Bok lånde till {DateTime.Now.AddMonths(1)}");
        }

        private void ReturnBook()
        {
            Console.Write("Ange Lån ID: ");
            var loanId = int.Parse(Console.ReadLine());

            var _loan = _context.Loans.FirstOrDefault(l => l.LoanID == loanId);
            if (_loan == null) // om lån inte finns i databasen
            {
                Console.WriteLine("Lån inte hittat");
                return;
            }
            _loan.ReturnDate = DateTime.Now; // ändra returdatumet till nuvarande datum
            _context.Loans.Remove(_loan); // ta bort lån från tabelen Loans i databasen
            _context.SaveChanges();
            Console.WriteLine("Tack för återlämningen");
        }
        private void RemoveBook()
        {
            Console.Write("Ange Bok ID: ");
            var bookid = int.Parse(Console.ReadLine());
            var _book = _context.Books.FirstOrDefault(b => b.BookID == bookid);
            if (_book == null) // om boken inte finns i databasen
            {
                Console.WriteLine("Bok inte hittad");
                return;
            }
            _context.Books.Remove(_book); // ta bort boken från tabelen Books 
            _context.SaveChanges();
            Console.WriteLine("Bok borttagen.");
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