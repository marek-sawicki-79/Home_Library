// See https://aka.ms/new-console-template for more information

using HomeLibrary.BusinessLogic.Models;using HomeLibrary.GUI.CnsoleInput;


while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to Home Library application\n" +
                      "chose your action:" +
                      "\n1. to add new book to your home collection," +
                      "\n2. to see all books stored in this app," +
                      "\n3. to remove book from your collection," +
                      "\nx to exit application.");
    var userChoice = Console.ReadLine();
    var location = new Location();
    var newBook = new Book();

    switch (userChoice)
    {
        case "1":
           
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

            Console.Clear();
            Console.WriteLine("Now we are entering the book Location in your home library.");
            Console.WriteLine("Press any key, when you're ready.");
            Console.ReadKey();

            Console.WriteLine("Name the building:");
            location.Building = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Name the floor:");
            location.Floor = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Now name the room:");
            location.Room = Console.ReadLine();

            newBook.Location = location;
            LibraryManagement.AddBook(newBook);
            break;

        case "2":
            
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("Enter the title of the the book to remove from the list");
            break;

        case "x":
            Console.WriteLine("Goodbye");
            return;

        default:
            Console.WriteLine("Invalid input");
            break;

        
    }
        

    
}
