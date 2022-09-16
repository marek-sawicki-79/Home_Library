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
        public List<Book> Books { get; set; }  = new List<Book>();
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

        public void RemoveBook(string bookToRemove)
        {
            Books.RemoveAll(b => b.Title.Contains(bookToRemove));
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
