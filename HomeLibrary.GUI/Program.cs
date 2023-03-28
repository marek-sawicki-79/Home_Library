// See https://aka.ms/new-console-template for more information

using HomeLibrary.BusinessLogic.Models;
using HomeLibrary.GUI.CnsoleInput;
using System.Threading;



Console.Clear();
Console.WriteLine("Welcome to Home Library application\n" +
                  "chose your action:" +
                  "\n1. to add new book to your home collection," +
                  "\n2. to see all books stored in this app," +
                  "\n3. to remove book from your collection," +
                  "\n4. show all available information about a specific book," +
                  "\n5. find books by genre in your collection," +
                  "\n6. if you want to see the list of book genres in your collection," +
                  "\n7. show me books that are lent," +
                  "\n8. show me borrowed books," +
                  "\n'X' to exit application.");
Console.WriteLine();
var userChoice = Console.ReadLine();
var library = new LibraryManagement();

void GetBooks()
{
    List<Book> Books = library.GetBooks();
}

while (true)
{
    int id = library.GetBooks().Count; //need to re factor - books.count might be smaller than max id number
    List<Book> myBooks = library.GetBooks();

    switch (userChoice)
    {
        case "1":

            Console.Clear();
            string title = library.EnterTitle();
            Console.WriteLine();

            string author = library.EnterTheAuthor();
            Console.WriteLine();

            string publishingHouse = library.EnterPublishingHouse();
            Console.WriteLine();

            string isbnNumber = library.IsbnNumberAdd();
            Console.WriteLine();

            string genre = library.EnterBookGenre();
            Console.WriteLine();

            string edition = library.RomanNumeralsInput();
            Console.WriteLine();

            int numberOfPages = library.AddNumberOfPages();
            Console.WriteLine();

            string seriesTitle = library.SeriesTitleInput();
            Console.WriteLine();

            int yearOfPublish = library.YearOfPublishInput();
            Console.WriteLine();

            string publicationLanguage = library.AddPublicationLanguage();
            Console.WriteLine();

            DateTime collectionAddDate = library.AddBookAcquisitionDate();
            Console.WriteLine();

            string bookSummary = library.AddBookSummary();
            Console.WriteLine();

            int yourRating = library.RateYourBook();
            Console.WriteLine();

            BookStatus bookStatus = library.AddBookStatus();

            Location location = library.AddLocation();

            id = id++;

            var newBook = new Book(id, title, author, publishingHouse, genre, edition, seriesTitle, yearOfPublish,
                yourRating, location, bookStatus, isbnNumber, bookSummary, collectionAddDate, numberOfPages,
                publicationLanguage);
            library.AddBook(newBook);
            break;



        case "2":
            Console.Clear();
            library.DisplayAllBooks();
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("Enter the title of the book to remove from the list");
            var bookToRemove = Console.ReadLine();
            library.RemoveBook(bookToRemove);
            break;

        case "4":
            Console.WriteLine("Write the title of the book you are looking for:");
            string bookToSearch = Console.ReadLine();
            library.SearchBookByTitle(bookToSearch);
            break;

        case "5":
            Console.WriteLine("What book genre are you looking for?");
            string genreToFind = Console.ReadLine();
            library.SearchBooksByGenre(genreToFind);
            break;

        case "6":
            Console.WriteLine("Available book genres:");
            library.SearchGenres();
            break;

        case "7":
            Console.WriteLine("Lent books:");
            library.SearchLent(myBooks);
            break;

        case "8":
            Console.WriteLine("Borrowed books:");
            library.SearchBorrowed(myBooks);
            break;

        case "x":
            Console.WriteLine("Goodbye");
            Thread.Sleep(3000);
            return;

        default:
            Console.WriteLine("Invalid input");
            break;
    }
    Console.WriteLine();
    Console.WriteLine("Choose your action:" +
                  "\n1.to add new book to your home collection, " +
                  "\n2. to see all books stored in this app," +
                  "\n3. to remove book from your collection," +
                  "\n4. show all available information about a specific book," +
                  "\n5. find books by genre in your collection," +
                  "\n6. if you want to see the list of book genres in your collection," +
                  "\n7. show me books that are lent," +
                  "\n8. show me borrowed books," +
                  "\n'X' to exit application.");
    Console.WriteLine();
    userChoice = Console.ReadLine();


}
