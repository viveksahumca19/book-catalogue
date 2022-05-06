using BookCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalogueTest.Mockdata
{
    public static class BookMockdata
    {
        public static List<BookResult> GetBooksdata()
        {
            return new List<BookResult> {
              new BookResult{bookId=2,authorName="Dr. A.P.J. Abdul Kalam", bookTitle="My Journey",iSBN="ISBN000000013",publicationDate=Convert.ToDateTime("2022-12-10") }
              //new BookResult{bookId=3,authorName="Dr. Bibek Debroy", bookTitle="Making of New India",iSBN="ISBN000000014",publicationDate=Convert.ToDateTime("2020-12-10") },
              //new BookResult{bookId=4,authorName="Jeet Thayil", bookTitle="Names of the Women",iSBN="ISBN000000015",publicationDate=Convert.ToDateTime("2022-12-10") },
              //new BookResult{bookId=5,authorName="Dr. Shailendra Joshi", bookTitle="Suparipalana",iSBN="ISBN000000016",publicationDate=Convert.ToDateTime("2022-12-10") },
              //new BookResult{bookId=6,authorName="Nitin Gokhale", bookTitle="Manohar Parrikar: Brilliant Mind, Simple Life",iSBN="ISBN000000017",publicationDate=Convert.ToDateTime("2022-12-10") },
              //new BookResult{bookId=7,authorName="Utkal Keshari Harekrushna Mahtab", bookTitle="Odisha Itihaas",iSBN="ISBN000000018",publicationDate=Convert.ToDateTime("2022-12-10") },
              //new BookResult{bookId=8,authorName="PM Narendra Modi", bookTitle="The Braille edition of the book Exam Warriors",iSBN="ISBN000000019",publicationDate=Convert.ToDateTime("2022-12-10") }
            };

        }
        public static List<BookResult> EmptyBooksdata()
        {
            return new List<BookResult>();  

        }

        public static ResponseMessage EmptyResponseMessage()
        {
            return new ResponseMessage();

        }
        public static BookSearch AddSearchValue()
        {
            return new BookSearch { authorName = "Dr. A.P.J. Abdul Kalam", bookTitle = "My Journey", iSBN = "ISBN" };
        }
        public static BookSearch AddSearchValuebyWrong()
        {
            return new BookSearch { authorName = "@", bookTitle = "@", iSBN = "@" };
        }

        public static BookSearch AddSearchValuebyEmpty()
        {
            return new BookSearch { authorName = "", bookTitle = "", iSBN = "" };
        }
        public static Book AddbookValuebyEmpty()
        {
            return new Book() { };
        }
        public static Book AddBookdata()
        {
            return new Book { authorName = "PM Narendra Modi", bookTitle = "The Braille edition of the book Exam Warriors", iSBN = "", publicationDate = Convert.ToDateTime("2022-12-10") };
        }
        public static Book updateBookdatabyBookidzero()
        {
            return new Book {bookId=0, authorName = "PM Narendra Modi", bookTitle = "The Braille edition of the book Exam Warriors", iSBN = "ISBN000000019", publicationDate = Convert.ToDateTime("2022-12-10") };
        }
        public static Book updateBookdatabyBookid()
        {
            return new Book { bookId = 12, authorName = "PM Narendra Modi", bookTitle = "The Braille edition of the book Exam Warriors", iSBN = "ISBN000000019", publicationDate = Convert.ToDateTime("2022-12-10") };
        }

        public static ResponseMessage updateBookdatabyBookidResponse()
        {
            return new ResponseMessage { statusCode = 200, response_Message = "Book information  has been updated successfully", data=null};
        }
        public static ResponseMessage deleteSuccessResponse()
        {
            return new ResponseMessage { statusCode = 200, response_Message = "Book information  has been removed successfully", data = null };

        }
        public static ResponseMessage AddBookDataSuccessResponse()
        {
            return new ResponseMessage { statusCode = 200, response_Message = "Book information  has been saved successfully", data = null };

        }
        public static Book AddBookdatabyEmpty()
        {
            return new Book { authorName = "", bookTitle = "", iSBN = "", publicationDate = Convert.ToDateTime("2022-12-10") };
        }
    }
}
