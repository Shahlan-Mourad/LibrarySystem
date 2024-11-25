using LibrarySystem.Data; 
using LibrarySystem.Models; 
using Microsoft.EntityFrameworkCore; 
using System; 
using System.Linq;


namespace LibrarySystem.Services
{
    public class LibraryService
    {
        private readonly LibraryContext _context;
        public LibraryService(LibraryContext context)
        {
             _context = context;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Lägg till data");
            Console.WriteLine("2. Läs data");

            var val = Console.ReadLine();

            if (val == "1")
            { 
            try
            {
                val = Console.ReadLine();
                switch (val)
                {  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            }

            
            
               
            
        }
    }
    
}
