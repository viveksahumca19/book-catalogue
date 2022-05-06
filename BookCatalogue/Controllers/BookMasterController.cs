using BookCatalogue.Models;
using BookCatalogue.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCatalogue.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BookMasterController : ControllerBase
    {
     private readonly   IBookService iBookService;

        public BookMasterController(IBookService _ibookService)
        {
            iBookService = _ibookService;
        }
        /// <summary>
        /// This service use for Book list with search criteria - title, author or by ISBN 
        /// </summary>
        /// <param name="bookSearch"></param>
        /// <returns></returns>
        [HttpGet("GetBooksData")]
        public  async Task< IActionResult> GetBooksData(BookSearch bookSearch)
        {
            var objresponse = new ResponseMessage();
            try
            {
                  
                var result = await  iBookService.GetBookData(bookSearch);
                if (result.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                 
                return BadRequest();
            }

              
        }
        /// <summary>
        /// this service use for adding new information in Book table
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
        [HttpPost("Addbooks")]
        public IActionResult Addbooks(Book objbook)
        {
            var objresponse = new ResponseMessage();
            try
            {
                objresponse = iBookService.bookAddDetail(objbook);
            }
            catch (Exception ex)
            {
                objresponse.statusCode = (int)HttpStatusCode.ExpectationFailed;
                objresponse.response_Message = ex.Message;
            }

            return Ok(objresponse);
        }
        /// <summary>
        /// this service use for update book information by book id in Book table
        /// </summary>
        /// <param name="objbook"></param>
        /// <returns></returns>
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Book objbook)
        {
            var objresponse = new ResponseMessage();
            //try
            //{
            if (objbook.bookId == 0)
            { return NoContent(); }
            else
            {
                objresponse = iBookService.bookUpdateDetail(objbook);
                return Ok(objresponse);
            }
            //}
            //catch (Exception ex)
            //{
            //    objresponse.statusCode = (int)HttpStatusCode.ExpectationFailed;
            //    objresponse.response_Message = ex.Message;
            //}

            //return Ok(objresponse);
        }

        /// <summary>
        ///        this service use for removing book information in Book table
        /// </summary>
        /// <param name="bookIdint"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBookData")]
        public IActionResult DeleteBookData(int bookIdint)
        {
            var objresponse = new ResponseMessage();
            //try
            //{
            if (bookIdint == 0)
            { return NoContent(); }
            else
            {
                objresponse = iBookService.bookRemoveDetail(bookIdint);
                return Ok(objresponse);
            }
            //}
            //catch (Exception ex)
            //{
            //    objresponse.statusCode = (int)HttpStatusCode.ExpectationFailed;
            //    objresponse.response_Message = ex.Message;
            //}

            
        }
    }
}
