using BookCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookCatalogue.DataAcess
{
   
    public class BookAccess
    {

        BookContext _dbContext;
        ResponseMessage errorMessage;
        List<UDParameters> objUdParamList;
        DataSet ds;
        DataUtility DataUtility;
        public BookAccess(BookContext dbContext, DataUtility dataUtility)
        {
           _dbContext = dbContext;
            DataUtility = dataUtility;
            errorMessage = new ResponseMessage();
        }

        public ResponseMessage bookAddDetail(Book book)
        {
            errorMessage.statusCode = (int)HttpStatusCode.OK;
            try
            {
                book.isActive = true;
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                errorMessage.response_Message = CommonMessage.bookDataSaveSuccessMsg;
            }
            catch (Exception ex)
            {
                errorMessage.statusCode = (int)HttpStatusCode.ExpectationFailed;
                errorMessage.response_Message = ex.InnerException.ToString();
            }
            return errorMessage;
        }
        public ResponseMessage bookRemoveDetail(int bookid)
        {
             
            errorMessage.statusCode = (int)HttpStatusCode.OK;
            try
            {
                var objbook = _dbContext.Books.Where(m => m.bookId == bookid && m.isActive == true).FirstOrDefault();
                if (objbook != null)
                {
                    objbook.isActive = false;
                    _dbContext.SaveChanges();
                    errorMessage.response_Message = CommonMessage.bookDataRemoveSuccessMsg;
                }
                else
                {
                    errorMessage.response_Message = CommonMessage.bookDataNotExistsMsg;
                }
            }
            catch (Exception ex)
            {
                errorMessage.statusCode = (int)HttpStatusCode.ExpectationFailed;
                errorMessage.response_Message = ex.Message;
            }
            return errorMessage;
        }
        public ResponseMessage bookUpdateDetail(Book book)
        {
            errorMessage.statusCode = (int)HttpStatusCode.OK;
            try
            {
                var objbook = _dbContext.Books.Where(m => m.bookId == book.bookId && m.isActive == true).FirstOrDefault();
                if (objbook != null)
                {
                   
                    objbook.authorName = book.authorName;
                    objbook.bookTitle = book.bookTitle;
                    objbook.iSBN = book.iSBN;
                    objbook.publicationDate = book.publicationDate;
                    _dbContext.SaveChanges();
                    errorMessage.response_Message = CommonMessage.bookDataUpdateSuccessMsg;
                }
                else
                {
                    errorMessage.response_Message = CommonMessage.bookDataNotExistsMsg;
                }
            }
            catch (Exception ex)
            {
                errorMessage.statusCode = (int)HttpStatusCode.ExpectationFailed;
                errorMessage.response_Message = ex.InnerException.ToString();
            }
            return errorMessage;
        }

        public async Task< List<BookResult>> GetBookData(BookSearch bookSearch)
        {
            errorMessage.statusCode = (int)HttpStatusCode.OK;
            List<BookResult> objBooklist = new List<BookResult>();
            try
            {
                objUdParamList = new List<UDParameters>();
                objUdParamList.Add(new UDParameters() { key = "@authorName", value = bookSearch.authorName });
                objUdParamList.Add(new UDParameters() { key = "@iSBN", value = bookSearch.iSBN });
                objUdParamList.Add(new UDParameters() { key = "@bookTitle", value = bookSearch.bookTitle });
                ds = new DataSet();
                ds = DataUtility.GetDataSet(DatabaseConstants.uspSearchBookdetails, objUdParamList);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    objBooklist.Add(new BookResult
                    {
                        bookId = Convert.ToInt32(dr["bookId"]),                        
                        authorName = Convert.ToString(dr["authorName"]),
                        iSBN = Convert.ToString(dr["iSBN"]),
                        bookTitle = Convert.ToString(dr["bookTitle"]),
                        publicationDate=Convert.ToDateTime(dr["publicationDate"])
                    });
                }
                errorMessage.data = objBooklist;
            }
            catch (Exception ex)
            {
                errorMessage.statusCode = (int)HttpStatusCode.ExpectationFailed;
                errorMessage.response_Message = ex.Message;
            }
            return objBooklist;
        }
    }
}
