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
                  "\nx to exit application.");
var userChoice = Console.ReadLine();
var library = new LibraryManagement();

while (true)
{
    switch (userChoice)
    {
        case "1":
            var newBook = new Book();
            Console.Clear();

            Console.WriteLine("Enter book title:");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Type in the author:");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Enter publishing house:");
            newBook.PublishingHouse = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Enter the genre of the book.\n If you don't want to do that, press enter:");
            newBook.Genre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Write in Roman numerals the edition of the book:");
            newBook.Edition = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("If it is a part of a book series, enter it's name:");
            newBook.SeriesTitle = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("When it was published:");
            newBook.YearOfPublish = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("If you've read it already, please rate it (1-5):");
            newBook.YourRating = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            var status = new BookStatus();
            Console.Clear();
            Console.WriteLine("Now we are entering the status of the book.");
            Console.WriteLine("Press any key, when you're ready.");
            Console.ReadKey();

            Console.WriteLine("Is this book yours (Y/N) or borrowed?");
            string answer = Console.ReadLine().ToLower();
            if(answer == "y")
            {
                status.isItYours = true;
                Console.WriteLine("Have you lend it to someone? (Y/N)");
                var input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("Write necessary information about it - e.g. who has it now.");
                    status.lendedToInfo = Console.ReadLine();
                }
                else if (input == "n")
                {
                    var location = new Location();
                    Console.Clear();
                    Console.WriteLine("Now we are entering the book Location in your home library.");
                    Console.WriteLine("Press any key, when you're ready.");
                    Console.ReadKey();

                    Console.Clear();
                    Console.WriteLine("Name the building:");
                    location.Building = Console.ReadLine();
                    Console.WriteLine("");

                    Console.WriteLine("Name the floor:");
                    location.Floor = Console.ReadLine();
                    Console.WriteLine("");

                    Console.WriteLine("Now name the room:");
                    location.Room = Console.ReadLine();

                    newBook.Location = location;
                }
                else
                {
                    Console.WriteLine("Illegible answer. Is this book yours? \nPlease answer 'Y' for yes or 'N' for no.");
                }
            }
            else if(answer == "n")
            {
                status.isItYours = false;
            }
            else
            {
                Console.WriteLine("Illegible answer. Is this book yours? \nPlease answer 'Y' for yes or 'N' for no.");
            }
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

        case "x":
            Console.WriteLine("Goodbye");
            Thread.Sleep(3000);
            return;

        default:
            Console.WriteLine("Invalid input");
            break;
    }

    Console.WriteLine("Choose your action");
    userChoice = Console.ReadLine();


}
