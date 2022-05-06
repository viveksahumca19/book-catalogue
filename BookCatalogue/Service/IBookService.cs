using BookCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Service
{
    public interface IBookService
    {
        ResponseMessage bookAddDetail(Book book);
        ResponseMessage bookRemoveDetail(int bookid);
        ResponseMessage bookUpdateDetail(Book book);
        Task<List<BookResult>> GetBookData(BookSearch bookSearch);
      }
}
