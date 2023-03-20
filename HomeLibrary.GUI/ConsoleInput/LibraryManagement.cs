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
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book(0, "Pamiętnik znaleziony w wannie", "Stanisław Lem", "Wydawnictwo Literackie",
                "Sci-Fi novel", "I", "none", 2000, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null)),
            new Book(1, "Eden", "Stanisław Lem", "Wydawnictwo Literackie Kraków-Wrocław",
                "Sci-Fi novel", "IV", "Stabisław Lem DZIEŁA", 1984, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null)),
            new Book(2, "Bogowie, Honor i Ankh-Morpork", "Terry Pratchett", "Prószyński i S-ka",
                "Fantasy - comedy - fantastyka - komedia", "I", "Świat Dysku", 2005, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null))
        };
        public List<Book> GetBooks()
        {
            return Books;
        }
        public void AddBook(Book newBook)
        {
            Books.Add(newBook);

            Console.WriteLine($"You have successfully added a new book to your home library!");
        }
        internal void ShowBookDetails(Book book)
        {

            Console.WriteLine($"{book.Title}\nwritten by {book.Author}\n it is a {book.Genre}" +
                              $"\n published by {book.PublishingHouse}" +
                              $"\n edition no. {book.Edition}." +
                              $"\nIt was published in {book.YearOfPublish}. It is a part " +
                              $"of a {book.SeriesTitle} series." +
                              $"\n your rate is {book.YourRating} out of 5." +
                              $"\n\nthe book is located in {book.Location.Building} " +
                              $"on {book.Location.Floor} in {book.Location.Room} room.");
            ShowStatus(book.BookStatus);
        }

        public void SearchBookByTitle(string title)
        {
            var book = Books.FirstOrDefault(x => x.Title.ToLower().Contains(title.ToLower()));
            ShowBookDetails(book);
        }
        public void SearchBooksByGenre(string genre)
        {
            var books = Books.Where(g => g.Genre.ToLower().Contains(genre.ToLower())).ToList();

            foreach (var book in books)
            {
                ShowBookDetails(book);
            }

        }
        internal void ShowGenre(Book book)
        {
            Console.WriteLine(book.Genre);
        }
        public void SearchGenres()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"\t{book.Genre}");
            }
        }
        public void RomanNumeralsCheck(string editionString) //to be finished later//regex?
        {
            List<char> romanNumerals = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            List<char> userInput = editionString.ToCharArray().ToList();
            var areRomanNumerals = userInput.All(romanNumerals.Contains);


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
            else if(status.IsItYours == false &(status.IsLended == false || status.IsLended == true))
            {
                Console.WriteLine($"This book is borrowed.\nHere is some information about it:\n{status.BorrowedFromInfo}");
            }
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
                Console.WriteLine($"{book.Title}, by {book.Author}, published by {book.PublishingHouse} in {book.YearOfPublish}\t edition no. {book.Edition}.");
            }
        }
    }
}
