using BookCatalogue.DataAcess;
using BookCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Service
{
    public class BookService:IBookService
    {
        BookAccess _bookAccess;
        public BookService(BookAccess bookAccess)
        {
            _bookAccess = bookAccess;
        }
        public ResponseMessage bookAddDetail(Book book) {
            return _bookAccess.bookAddDetail(book);
        }
        public ResponseMessage bookRemoveDetail(int bookid) {
            return _bookAccess.bookRemoveDetail(bookid);
        }
        public ResponseMessage bookUpdateDetail(Book book) {
            return _bookAccess.bookUpdateDetail(book);
        }
        public ResponseMessage GetBookData(BookSearch bookSearch) {
            return _bookAccess.GetBookData(bookSearch);
        }
    }
}
