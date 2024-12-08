using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Models;
using System;
using System.Linq;


namespace LibrarySystem.ReadData
{

    public class csReadData
    {

        private readonly LibraryContext _context;
        public csReadData(LibraryContext context)
        {
            _context = context; //  hela ListService-klassen kan använda _context för att interagera med databasen.
        }
        public void ListAllBooks()
        {
            var books = _context.Books
                    .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                    .ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Författare: {book.Author}, Genre: {book.Genre}, PublishedYear: {book.Publication_Year} BookID {book.BookID}");
                     
                    foreach (var ba in book.BookAuthors)
                    {
                        Console.WriteLine($"Author: {ba.Author.Name}");
                    }
                }          
        }


        public void ListAllMembers()
        {
            var members = _context.Members.ToList();
            foreach (var member in members)
            {
                Console.WriteLine($"Name: {member.FristName} {member.LastName}, Email: {member.Email}, MembershipStartDate: {member.MembershipStartDate} MemberID {member.MemberID}");
            }
        }
        public void ListAllLoans()
        {
            var loans = _context.Loans
            .Include(l => l.Book)
            .Include(l => l.Member)
            .ToList();
            foreach (var loan in loans)
            {
                Console.WriteLine($"Book: {loan.Book.Title}, Borrower: {loan.Member.FristName} {loan.Member.LastName}, LoanDate: {loan.LoanDate}, ReturnDate: {loan.ReturnDate}, LoanID {loan.LoanID}");
            }
        }

    }
}