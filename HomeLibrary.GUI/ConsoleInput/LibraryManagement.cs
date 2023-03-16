using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLibrary.BusinessLogic.Models;

namespace HomeLibrary.GUI.CnsoleInput
{
    internal class LibraryManagement
    {
        //static List<Location> Locations { get; set; } = new List<Location>()
        //{
        //    new Location("house", "underground", ""),
        //    new Location("house", "1st", "study"),
        //    new Location("house", "2nd", "east bedroom"),
        //    new Location("house", "attic", "")
        //};
        //public static List<BookStatus> BookStatuses { get; set; } = new List<BookStatus>()
        //{
        //    new BookStatus(false, true, "jjj", "ooo"),
        //};
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book(0, "Pamiętnik znaleziony w wannie", "Stanisław Lem", "Wydawnictwo Literackie",
                "Sci-Fi", "I", "none", 2000, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null)),
            new Book(1, "Eden", "Stanisław Lem", "Wydawnictwo Literackie Kraków-Wrocław",
                "Sci-Fi", "IV", "Stabisław Lem DZIEŁA", 1984, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null))
        };
        public List<Book> GetBooks()
        {
            return Books;
        }
        public void AddBook(Book newBook)
        {
           Books.Add(newBook);

            Console.WriteLine($"You have successfully added a new book to your home library!" +
                              $"\nit is a {newBook.Genre} named {newBook.Title}, written by {newBook.Author}" +
                              $"\nand published by {newBook.PublishingHouse}" +
                              $"\n edition no. {newBook.Edition}.\n" +
                              $"It was published in {newBook.YearOfPublish}. It is a part " +
                              $"of a {newBook.SeriesTitle} series." +
                              $"\n your rate is {newBook.YourRating} out of 5." +
                              $"\n\nthe book is located in {newBook.Location.Building} " +
                              $"on {newBook.Location.Floor} in {newBook.Location.Room} room.");
        }
        internal void ShowStatus(BookStatus status)
        {
            if(status.IsItYours == true & status.IsLended == true)
            {
                Console.WriteLine($"The book has been lent\nHere is some information about it:\n{status.LendedToInfo} ");
            }
            else if(status.IsItYours == true & status.IsLended == false)
            {
                Console.WriteLine("You haven't lent it. It should be int the entered location. ");
            }
            else if(status.IsItYours == false)
            {
                Console.WriteLine($"This book is borrowed.\nHere is some information about it:\n{status.BorrowedFromInfo}");
            }
        }

        public void IllegibleAnswer()
        {
            Console.WriteLine("Illegible answer. Is this book yours? \nPlease answer 'Y' for yes or 'N' for no.");
        }

        public void RemoveBook(string bookToRemove)
        {
            Books.RemoveAll(b => b.Title.Contains(bookToRemove));
        }

        public void AddLocation(Location newLocation)
        {
            Console.Clear();
            Console.WriteLine("Now we are entering the book Location in your home library.");
            Console.WriteLine("Press any key, when you're ready.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Name the building:");
            newLocation.Building = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Name the floor:");
            newLocation.Floor = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Now name the room:");
            newLocation.Room = Console.ReadLine();
        }

       public void DisplayAllBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title}, by {book.Author}, published by {book.PublishingHouse} in {book.YearOfPublish}" +
                                  $"\n\t edition no. {book.Edition}.");
            }
        }
    }
}
