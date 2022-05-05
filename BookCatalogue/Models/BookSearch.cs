using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Models
{
    public class BookSearch
    {
        [Required]
        public string authorName { get; set; }
        [Required]
        public string bookTitle { get; set; }
        [Required]
        public string iSBN { get; set; }
    }
}
