﻿// See https://aka.ms/new-console-template for more information

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
                  "\nx to exit application.");
var userChoice = Console.ReadLine();
var library = new LibraryManagement();

void GetBooks()
{
    List<Book> Books = library.GetBooks();
}
//var newBook = new Book();
//var bookStatus = new BookStatus();
//var location = new Location();

while (true)
{
    Location location = new Location("", "", "");
    BookStatus bookStatus = new BookStatus(false, false, "", "");
    bool isLended;
    bool borrowedFrom;
    bool isItYours;
    string lendedToInfo;
    string borrowedFromInfo;
    int id = library.GetBooks().Count; //need to re factor - books.count might be smaller than max id number

    switch (userChoice)
    {
        case "1":

            Console.Clear();

            Console.WriteLine("Enter book title:");
            var title = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Type in the author:");
            var author = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Enter publishing house:");
            var publishingHouse = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Enter the genre of the book.\n If you don't want to do that, press enter:");
            var genre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Write in Roman numerals the edition of the book:");
            var edition = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("If it is a part of a book series, enter it's name:");
            var seriesTitle = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("When it was published:");
            var yearOfPublish = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("If you've read it already, please rate it (1-5):");
            var yourRating = int.Parse(Console.ReadLine());
            Console.WriteLine("");


            Console.Clear();
            Console.WriteLine("Now we are entering the status of the book.");
            Console.WriteLine("Press any key, when you're ready.");
            Console.ReadKey();

            Console.WriteLine("Is this book yours (Y/N) or borrowed?");
            string answer = Console.ReadLine().ToLower();



            if (answer == "y")
            {
                isItYours = true;
                Console.WriteLine("Have you lend it to someone? (Y/N)");
                var input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                     isLended = true;
                    Console.WriteLine("Write necessary information about it - e.g. who has it now.");
                    lendedToInfo = Console.ReadLine();
                    borrowedFromInfo = "";
                }
                else if (input == "n")
                {
                    isLended = false;
                    library.AddLocation(location);
                    lendedToInfo = "";
                    borrowedFromInfo = "";
                }
                else
                {
                    library.IllegibleAnswer();
                }


            }
            else if(answer == "n")
            {
                isItYours = false;
                isLended = false;
                Console.WriteLine("Where did you get it from?");
                borrowedFromInfo = Console.ReadLine();
                lendedToInfo = "";
                library.AddLocation(location);
            }
            else
            {
                library.IllegibleAnswer();
            }
            id = id++;
            var newBook = new Book(id, title, author, publishingHouse, genre, edition, seriesTitle, yearOfPublish, yourRating, location, bookStatus);
            newBook.BookStatus = bookStatus;
            newBook.Location = location;
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

        case "x":
            Console.WriteLine("Goodbye");
            Thread.Sleep(3000);
            return;

        default:
            Console.WriteLine("Invalid input");
            break;
    }

    Console.WriteLine("Choose your action" +
                  "\n1.to add new book to your home collection, " +
                  "\n2. to see all books stored in this app," +
                  "\n3. to remove book from your collection," +
                  "\n4. show all available information about a specific book," +
                  "\n5. find books by genre in your collection," +
                  "\nx to exit application.");
    userChoice = Console.ReadLine();


}
