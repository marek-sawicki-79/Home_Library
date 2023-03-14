using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BusinessLogic.Models
{
    public class BookStatus
    {
        public bool IsLended { get; set; }
        public bool IsItYours { get; set; }
        public string LendedToInfo { get; set; }
        public string BorrowedFromInfo { get; set; }

        public BookStatus(bool isLended, bool isItYours, string lendedToInfo, string borrowedFromInfo)
        {
            IsLended = isLended;
            IsItYours = isItYours;
            LendedToInfo = lendedToInfo;
            BorrowedFromInfo = borrowedFromInfo;
        }
    }
}
