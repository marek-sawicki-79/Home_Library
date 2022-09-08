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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Edition { get; set; }
        public string? SeriesTitle { get; set; }
        public int YearOfPublish { get; set; }
        public int YourRating { get; set; }

        public Location Location { get; set; }


    }
}
