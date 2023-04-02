using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BusinessLogic.Models
{
    public class Book
    {
        private static int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public string Genre { get; set; }
        public string Edition { get; set; }
        public string? SeriesTitle { get; set; }
        public int YearOfPublish { get; set; }
        public int YourRating { get; set; }
        public string IsbnNumber { get; set; }
        public string? BookSummary { get; set; }
        public DateTime CollectionAddDate  { get; set; }
        public int NumberOfPages { get; set; }
        public string PublicationLanguage { get; set; }


        public Location Location { get; set; }
        public BookStatus BookStatus { get; set; }

        public Book(int id, string title, string author, string publishingHouse, string genre,
            string edition, string seriesTitle, int yearOfPublish, int yourRating,
            Location location, BookStatus bookStatus, string isbnNumber, string bookSummary, DateTime collectionAddDate,
            int numberOfPages, string publicationLanguage)
        {
            Id = id;
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
            Genre = genre;
            Edition = edition;
            SeriesTitle = seriesTitle;
            YearOfPublish = yearOfPublish;
            YourRating = yourRating;
            Location = location;
            BookStatus = bookStatus;
            IsbnNumber = isbnNumber;
            BookSummary = bookSummary;
            CollectionAddDate =collectionAddDate;
            NumberOfPages = numberOfPages;
            PublicationLanguage = publicationLanguage;
        }
    }
}
