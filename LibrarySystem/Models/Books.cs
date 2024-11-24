

namespace LibrarySystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Publication_Date { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Loan> Loans { get; set; }
           
    }
}