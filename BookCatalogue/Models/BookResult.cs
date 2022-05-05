using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Models
{
    public class BookResult
    {

        public int bookId { get; set; }
        public string bookTitle { get; set; }
        public string authorName { get; set; }
        public string iSBN { get; set; }
        public DateTime publicationDate { get; set; }



    }
}
