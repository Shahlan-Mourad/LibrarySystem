using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;

public class ReadData
{
    public void ListAllBooks()
    {
        var context = new LibraryContext();
        var books = context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Genre: {book.Genre}, PublishedYear: {book.Publication_Date}");
                foreach (var ba in book.BookAuthors)
                {
                    Console.WriteLine($"Author: {ba.Author.Name}");
                }
            }
                
    }
    public void ListAllMembers()
    {
        var context = new LibraryContext();
        var members = context.Members.ToList();
        foreach (var member in members)
        {
            Console.WriteLine($"Name: {member.FristName} {member.LastName}, Email: {member.Email}, MembershipStartDate: {member.MembershipStartDate}");
        }
    }
    public void ListAllLoans()
    {
        var context = new LibraryContext();
        var loans = context.Loans
        .Include(l => l.Book)
        .Include(l => l.Member)
        .ToList();
        foreach (var loan in loans)
        {
            Console.WriteLine($"Book: {loan.Book.Title}, Borrower: {loan.Member.FristName} {loan.Member.LastName}, LoanDate: {loan.LoanDate}, ReturnDate: {loan.ReturnDate}");
        }
    }
    
}