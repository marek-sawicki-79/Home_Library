using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BusinessLogic.Models
{
    public class BookStatus
    {
        public bool isBorrowed { get; set; }
        public bool isItYours { get; set; }
        public string? lendedToInfo { get; set; }
        public string? borrowedFromInfo { get; set; }
    }
}
