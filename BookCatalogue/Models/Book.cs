using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
            

        [Display(Name = "Book  Title")]
        [Required]
        public string bookTitle { get; set; }

        [Display(Name = "Author Name")]
        [Required]
        public string authorName { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        [MinLength(13, ErrorMessage = "Please enter ISBN(13 characters)"), MaxLength(13, ErrorMessage = "Please enter ISBN(13 characters)")]
        public string iSBN { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publication Date")]
        public DateTime publicationDate { get; set; }


        public Boolean isActive { get; set; }
         
    }
}
