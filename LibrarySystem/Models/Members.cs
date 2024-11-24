

namespace  LibrarySystem.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public ICollection<Loan> loans { get; set; }

        
        
        
       
        
        
    }
}