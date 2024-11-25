using LibrarySystem.Data; 
using LibrarySystem.Models; 
using LibrarySystem.AddData;
using LibrarySystem.ReadData;
using Microsoft.EntityFrameworkCore; 
using System; 
using System.Linq;
using System.ComponentModel.Design;



namespace LibrarySystem.Services
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            using (var context = new LibraryContext())
            { 
                var list = new csReadData(context);
                var add = new csAddData(context);
                
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Välj ett alternativ: \n\n ");
                    Console.WriteLine("1. Lista alla böcker");
                    Console.WriteLine("2. Lista alla medlemmar");
                    Console.WriteLine("3. Lista alla utlånade böcker");
                    Console.WriteLine("4. Add Book eller bli medlem");
                    Console.WriteLine("5. Exit");
                    var _input = Console.ReadLine();
                    switch (_input)
                    {
                        case "1":
                        list.ListAllBooks();
                        break;
                        case "2":
                        list.ListAllMembers();
                        break;
                        case "3":
                        list.ListAllLoans();
                        break;
                        case "4":
                        add.DisplayAdd();
                        break;
                        case "5":
                        exit = true;
                        break;
                        default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                    } 
                } 
            } 
        }
    }
    
}

       
    
