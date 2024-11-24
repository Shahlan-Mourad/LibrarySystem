
namespace LibrarySystem.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Book book { get; set; }
        public Member member { get; set; }
    }
}