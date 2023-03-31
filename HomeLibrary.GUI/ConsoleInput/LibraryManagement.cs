using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLibrary.BusinessLogic.Models;
using Newtonsoft.Json;

namespace HomeLibrary.GUI.CnsoleInput
{
    internal class LibraryManagement
    {
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book(0, "Pamiętnik znaleziony w wannie", "Stanisław Lem", "Wydawnictwo Literackie",
                "Sci-Fi novel", "I", "none", 2000, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null),
                "ISBN 978-83-7469-032-1", "Jest to relacja z pierwszej ręki, dotycząca przeżyć agenta uwięzionego głęboko w podziemnym kompleksie wojskowym Nowego Pentagonu," +
                "gdzieś pod Górami Skalistymi. Świat i życie tajnego kompleksu rządowego przypominają kafkowskie wizje biurokracji i zagubienia w trybach maszyn urzędniczych.",
                new DateTime(2019, 7, 11), 339, "PL"),
            new Book(1, "Eden", "Stanisław Lem", "Wydawnictwo Literackie Kraków-Wrocław",
                "Sci-Fi novel", "IV", "Stanisław Lem DZIEŁA", 1984, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null),
                "ISBN 978-83-08-01292-2", "W wyniku błędów w obliczeniach rakieta z grupą kosmonautów przymusowo ląduje na planecie Eden. " +
                "Ludzie rozpoczynają naprawę wbitego w grunt statku, a także badanie planety, która " +
                "okazuje się zamieszkana przez istoty rozumne. Podczas poznawania nowego środowiska kosmonauci odkrywają niezrozumiałe z ziemskiego punktu widzenia rzeczy i zjawiska",
                new DateTime(1979, 8,23), 301, "PL"),
            new Book(2, "Bogowie, Honor i Ankh-Morpork", "Terry Pratchett", "Prószyński i S-ka",
                "Fantasy - comedy - fantastyka - komedia", "I", "Świat Dysku", 2005, 5, new Location("house", "1st floor", "study"), new BookStatus(false, true, null, null),
                "ISBN 978-83-7469032-1", "Książka opowiada o dwóch bogach, którzy przybywają do miasta Ankh-Morpork i rozpoczynają walkę o wpływy.", new DateTime(2005, 10, 5), 339, "PL"),
            new Book(3, "Powrót z gwiazd", "Stanisław Lem", "Wydawnictwo Literackie",
                "Sci-Fi", "I", "Stanisław Lem DZIEŁA", 2000, 5, new Location("house", "1st floor", "study"), new BookStatus(true, true, "amator pacynek(Macierewicza)", null),
                 "ISBN 978-83-08-02932-9", "Historia pilota kosmicznego, który powraca na Ziemię po długiej misji i odkrywa, że świat uległ radykalnym zmianom.", new DateTime(2003, 10, 18),
                 233, "PL"),
            new Book(4, "Królestwo", "Jo Nesbo", "Wydawnictwo Dolnośląskie",
                "Kryminał", "I", "Ślady zbrodni", 2020, 5, new Location("house", "1st floor", "study"), new BookStatus(false, false,  null, "próba "),
                "ISBN 978-83-271-6008-9", "Detektyw Harry Hole powraca do Oslo, by pomóc swojemu pasierbowi w rozwikłaniu sprawy zabójstwa", new DateTime(2), 746, "PL")
        };
        internal DateTime AddBookAcquisitionDate()
        {
            bool dateIsValid = false;
            DateTime dateOfAcquisition = default;
            Console.WriteLine("Did you get it today? (y/n)");
            string answer = Console.ReadLine().ToLower();
            DateTime oldestYear = new DateTime(1700, 1, 1);
            do

                {
                    if (string.IsNullOrEmpty(answer))
                {
                    BadDataMessage();
                    Console.WriteLine("'y' or 'n'.");
                }
                else if (answer != "y" && answer != "n")
                {
                    Console.WriteLine("Enter 'y' or 'n'.");
                }
                else if (answer == "y")
                {
                    dateOfAcquisition = DateTime.Now;
                    dateIsValid = true;
                }
                else if (answer == "n")
                {
                    Console.WriteLine("Please enter the date (yyyy-MM-dd)");
                    string input = Console.ReadLine();
                    DateTime inputDate;
                    if(DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate))
                    {
                        dateOfAcquisition = inputDate;
                        dateIsValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid date in the format yyyy-MM-dd.");
                    }
                }
            } while (dateIsValid == false);
            return dateOfAcquisition;
        }
        internal string AddPublicationLanguage()
        {
            bool isValid = false;
            string publicationLanguage = null;
            Console.WriteLine("What language it is written in?");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 20)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 20 characters.");
                }
                else
                {
                    publicationLanguage = input;
                    isValid = true;
                }
            } while (isValid == false);
            return publicationLanguage;
        }
        internal int AddNumberOfPages()
        {
            bool isValid = false;
            int numberOfPages = 0;
            Console.WriteLine("Enter number of pages:");
            do
            {
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int result);
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (isInt == false)
                {
                    Console.WriteLine("Please enter number f pages using numerals.");
                }
                else if (isInt && 21450 < result)
                {
                    Console.WriteLine($"Your rating for this book >{result}< is off the charts."+
                        $"\nCurrently recorded longest book has 21450 pages." +
                        $"\nDo not exceed this length, please.");
                }
                else if (isInt && result < 10)
                {
                    Console.WriteLine("Seriously? less than 10 pages? It's more a pamflet than a book. I won't store it. It's beneath me.");
                }
                else
                {
                    numberOfPages = result;
                    isValid = true;
                }
            } while (isValid == false);
            return numberOfPages;
        }
        internal string AddBookSummary()
        {
            bool isValid = false;
            string bookSummary = null;
            Console.WriteLine("Add short book summary:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 1000)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 1000 characters.");
                }
                else
                {
                    bookSummary = input;
                    isValid = true;
                }
            } while (isValid == false);
            return bookSummary;
        }
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

            Console.WriteLine($"The book title is {book.Title}\nwritten by {book.Author}\n it is a {book.Genre}" +
                              $"\n published by {book.PublishingHouse}" +
                              $"\n edition no. {book.Edition}." +
                              $"\nIt was published in {book.YearOfPublish} in {book.PublicationLanguage} language, and consists of {book.NumberOfPages} pages"+
                              $"\nIt's ISBN number is: {book.IsbnNumber};" +
                              $"\nIt was added to your collection on {book.CollectionAddDate}." +
                              $"\nIt is a part  of a {book.SeriesTitle} series." +
                              $"\n your rate is {book.YourRating} out of 5." +
                              $"\nHere is a short summary of this book: \n\t{book.BookSummary}" +
                              $"\n\nthe book is located in {book.Location.Building} " +
                              $"\non {book.Location.Floor} in {book.Location.Room} room.");
            ShowStatus(book.BookStatus);
            Console.WriteLine();
        }
        public void SearchBookByTitle(string title)
        {
            var books = Books.Where(x => x.Title.ToLower().Contains(title.ToLower()));
            foreach (var book in books)
            {
                ShowBookDetails(book);
            }

        }
        public void SearchLent(List<Book> bookList)
        {
            var lentBooks = Books.Where(x => x.BookStatus.IsLended == true);
            foreach (var book in lentBooks)
            {
                ShowBookDetails(book);
            }

        }
        public void SearchBorrowed(List<Book> bookList)
        {
            var borrowedBooks = Books.Where(x => x.BookStatus.IsItYours == false);
            foreach (var book in borrowedBooks)
            {
                ShowBookDetails(book);
            }

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
        public string EnterTitle()
        {
            bool isValid = false;
            var title = "";
            Console.WriteLine("Enter book title:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if(input.Length >= 100)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 100 characters.");
                }
                else
                {
                    title = input;
                    isValid = true;
                }
            } while (isValid == false);
            return title;
        }
        public string EnterTheAuthor()
        {
            bool isValid = false;
            var author = "";
            Console.WriteLine("Type in the author:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 100)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 100 characters.");
                }
                else
                {
                    author = input;
                    isValid = true;
                }
            } while (isValid == false);
            return author;
        }
        public string EnterPublishingHouse()
        {
            bool isValid = false;
            var publishingHouse = "";
            Console.WriteLine("Type in the Publishing House:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 100)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 100 characters.");
                }
                else
                {
                    publishingHouse = input;
                    isValid = true;
                }
            } while (isValid == false);
            return publishingHouse;
        }
        public string IsbnNumberAdd()
        {
            bool isValid = false;
            string isbnNumber = null;
            Console.WriteLine("Inter ISBN number:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length != 17 && input.Length != 13)
                {
                    Console.WriteLine("Enter only numbers and dashes only.");
                }
                else if(input.Length == 13)
                {
                    isbnNumber = ($"ISBN 978-{input}");
                    isValid = true;
                }
                else
                {
                    isbnNumber = ($"ISBN {input}");
                    isValid = true;
                }
            } while (isValid == false);
            return isbnNumber;
        }
        public string EnterBookGenre()
        {
            bool isValid = false;
            var genre = "";
            Console.WriteLine("Enter the genre of the book:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 100)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 100 characters.");
                }
                else
                {
                    genre = input;
                    isValid = true;
                }
            } while (isValid == false);
            return genre;
        }
        public string RomanNumeralsInput()
        {
            List<char> romanNumerals = new List<char> { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            string edition = "";
            bool isValid = false;
            do
            {
                Console.WriteLine("Write in Roman numerals the edition of the book:");
                var inputToCheck = Console.ReadLine();

                if (string.IsNullOrEmpty(inputToCheck))
                {
                    BadDataMessage();
                }
                else
                {
                    List<char> userInput = inputToCheck.ToCharArray().ToList();
                    bool allOfUserInputIsInRomanNumerals = userInput.All(c => romanNumerals.Contains(c));

                    if (allOfUserInputIsInRomanNumerals == false)
                    {
                        Console.WriteLine("Please use characters from the set:" +
                        "\n'I', 'V', 'X', 'L', 'C', 'D', 'M'  ");
                    }
                    else
                    {
                        edition = inputToCheck;
                        isValid = true;
                    }
                }
            } while (isValid == false);

            return edition;
        }
        public string SeriesTitleInput()
        {
            bool isValid = false;
            var series = "Book series";
            Console.WriteLine("If it is a part of a book series, enter it's name:");
            do
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (input.Length >= 100)
                {
                    Console.WriteLine($"Your input {input} is to long. Please keep it up to 100 characters.");
                }
                else
                {
                    series = input;
                    isValid = true;
                }
            } while (isValid == false);
            return series;
        }
        public int YearOfPublishInput()
        {
            bool isValid = false;
            var yearOfPublish = 0;
            DateTime currentDate = DateTime.Now;
            int currentYear = (int)currentDate.Year;
            Console.WriteLine("When it was published:");
            do
            {
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int result);
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (isInt == false)
                {
                    Console.WriteLine("Please enter when the book was published using numbers.");
                }
                else if (isInt && currentYear < result || result < 1800)
                {
                    Console.WriteLine($"The year you have entered >{result}< is incorrect. Please enter a value between 1800 and current year.");
                }
                else
                {
                    yearOfPublish = result;
                    isValid = true;
                }
            } while (isValid == false);
            return yearOfPublish;
        }
        public int RateYourBook()
        {
            bool isValid = false;
            var rating = 0;
            Console.WriteLine("If you've read it already, please rate it (1-5):");
            do
            {
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int result);
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else if (isInt == false)
                {
                    Console.WriteLine("Please rate the book with numerical values.");
                }
                else if (isInt && 5 < result || result < 1)
                {
                    Console.WriteLine($"Your rating for this book >{result}< is off the charts. Please rate the book on a scale between 1 and 5.");
                }
                else
                {
                    rating = result;
                    isValid = true;
                }
            } while (isValid == false);
            return rating;
        }
        public Location AddLocation()
        {
            Location newLocation = new Location("", "", "");

            Console.Clear();
            Console.WriteLine("Now we are entering the book Location in your home library.");
            Console.WriteLine();

            bool buildingIsValid = false;
            bool floorIsValid = false;
            bool roomIsValid = false;

            do
            {
                Console.WriteLine("Name the building:");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else
                {
                    newLocation.Building = input;
                    buildingIsValid = true;
                }
            } while (buildingIsValid == false);

            do
            {
                Console.WriteLine("Name the floor:");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    BadDataMessage();
                }
                else
                {
                    newLocation.Floor = input;
                    floorIsValid = true;
                }
            } while (floorIsValid == false);
            do
            {
                Console.WriteLine("Now name the room:");
                Console.WriteLine();

                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter required data");
                }
                else
                {
                    newLocation.Room = input;
                    roomIsValid = true;
                }
            } while (roomIsValid == false);
            return newLocation;
        }
        public BookStatus AddBookStatus()
        {
            BookStatus bookStatus = new BookStatus(false, false, "", "");
            bool isLended = false;
            bool isItYours = false;
            string lendedToInfo = null;
            string borrowedFromInfo = null;
            bool isValid = false;

            Console.Clear();
            Console.WriteLine("Now we are entering the status of the book.");
            do
            {
                Console.WriteLine("Is this book yours (Y/N) or borrowed?");
                string answer = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(answer))
                {
                    BadDataMessage();
                    Console.WriteLine("'y' or 'n'.");
                }
                else if (answer != "y" && answer != "n")
                {
                    Console.WriteLine("Enter 'y' or 'n'.");
                }
                else if (answer == "y")
                {
                    isItYours = true;

                    while (true)
                    {


                        Console.WriteLine("Have you lend it to someone? (Y/N)");
                        var input = Console.ReadLine().ToLower();

                        if (string.IsNullOrEmpty(input))
                        {
                            BadDataMessage();
                            Console.WriteLine("'y' or 'n'.");
                        }
                        else if (input != "y" && input != "n")
                        {
                            Console.WriteLine("Enter 'y' or 'n'.");
                        }
                        else if (input == "y")
                        {
                            bookStatus.IsLended = true;
                            bookStatus.IsItYours = true;
                            Console.WriteLine("Write necessary information about it - e.g. who has it now.");
                            lendedToInfo = Console.ReadLine();
                            bookStatus.LendedToInfo = lendedToInfo;
                            bookStatus.BorrowedFromInfo = borrowedFromInfo;
                            isValid = true;
                            break;
                        }
                        else if (input == "n")
                        {
                            bookStatus.IsLended = false;
                            bookStatus.IsItYours = true;
                            bookStatus.IsLended = isLended;
                            bookStatus.LendedToInfo = lendedToInfo;
                            bookStatus.BorrowedFromInfo = borrowedFromInfo;
                            isValid = true;
                            break;
                        }
                    }
                }
                else if (answer == "n")
                {
                    bookStatus.IsItYours = false;
                    bookStatus.IsLended = isLended;
                    Console.WriteLine("Where did you get it from?");
                    borrowedFromInfo = Console.ReadLine();
                    bookStatus.BorrowedFromInfo = borrowedFromInfo;
                    bookStatus.LendedToInfo = lendedToInfo;
                    isValid = true;
                }
            } while (!isValid);

            return bookStatus;
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
        internal void BadDataMessage()
        {
            Console.WriteLine("Please enter required data");
        }
        public void RemoveBook(string bookToRemove)
        {
            Books.RemoveAll(b => b.Title.Equals(bookToRemove));
        }
        public void DisplayAllBooks()
        {
           
            if (!File.Exists(filePath))
            {
                foreach (var book in Books)
                {
                    Console.WriteLine($"{book.Title}, by {book.Author}, published by {book.PublishingHouse} in {book.YearOfPublish}\t edition no. {book.Edition}.");
                }
            }
            else
            {
                string jsonString = File.ReadAllText(filePath);
                var myLibrary = JsonConvert.DeserializeObject<List<Book>>(jsonString);
                foreach (var book in myLibrary)
                {
                    Console.WriteLine($"{book.Title}, by {book.Author}, published by {book.PublishingHouse} in {book.YearOfPublish}\t edition no. {book.Edition}.");
                }
            }            
        }
    }
}
