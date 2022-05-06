using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Models
{
    public class BookSearch
    {
        
        public string authorName { get; set; }
         
        public string bookTitle { get; set; }
       
        public string iSBN { get; set; }
    }
}
