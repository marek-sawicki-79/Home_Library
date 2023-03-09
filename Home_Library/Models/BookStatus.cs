using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BusinessLogic.Models
{
    internal class BookStatus
    {
        public bool isBorrowed { get; set; }
        public string? borrowedInfo { get; set; }
    }
}
