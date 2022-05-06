using BookCatalogue.Controllers;
using BookCatalogue.Models;
using BookCatalogue.Service;
using BookCatalogueTest.Mockdata;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookCatalogueTest.System.Controllers
{
    public class BookMasterTestController
    {
        [Fact]
        public  void SaveBooksData_ShouldReturn_200Status()
        {
            // Arrange
             
            var bookService = new Mock<IBookService>();
            var addbookdata= BookMockdata.AddBookdata();
            bookService.Setup(m => m.bookAddDetail(addbookdata)).Returns(BookMockdata.AddBookDataSuccessResponse());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result =  sut.Addbooks(addbookdata);

            //Assert
            //bookService.Verify(_ => _.bookAddDetail(addbookdata), Times.Exactly(1));
            object p = result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public void SaveBooksData_ShouldReturn_400Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            var addbookdata = BookMockdata.AddBookdatabyEmpty();
            bookService.Setup(m => m.bookAddDetail(addbookdata)).Returns(BookMockdata.EmptyResponseMessage());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = sut.Addbooks(addbookdata);

            //Assert
            object p = result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);

        }
        [Fact]
        public async Task GetBookdetails_ShouldReturn_200Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();             
            bookService.Setup(x => x.GetBookData(BookMockdata.AddSearchValue())).ReturnsAsync(BookMockdata.GetBooksdata());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = await  sut.GetBooksData(BookMockdata.AddSearchValue());

            //Assert
            object p = result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetBookdetails_ShouldReturn_204Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.GetBookData(BookMockdata.AddSearchValuebyWrong())).ReturnsAsync(BookMockdata.EmptyBooksdata());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = await sut.GetBooksData(BookMockdata.AddSearchValuebyWrong());

            //Assert
            object p = result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task GetBookdetails_ShouldReturn_400Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.GetBookData(BookMockdata.AddSearchValuebyEmpty())).ReturnsAsync(BookMockdata.EmptyBooksdata());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = await sut.GetBooksData(BookMockdata.AddSearchValuebyEmpty());

            //Assert
            object p = result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }

        

        [Fact]
        public void DeleteBookData_ShouldReturn_204Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.bookRemoveDetail(0)).Returns(BookMockdata.EmptyResponseMessage());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result =   sut.DeleteBookData(0);

            //Assert
            object p = result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public void DeleteBookData_ShouldReturn_200Status()
        {
            // Arrange
            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.bookRemoveDetail(10)).Returns(BookMockdata.deleteSuccessResponse());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = sut.DeleteBookData(10);

            //Assert
            object p = result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public void UpdateBook_ShouldReturn_204Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.bookRemoveDetail(0)).Returns(BookMockdata.EmptyResponseMessage());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = sut.DeleteBookData(0);

            //Assert
            object p = result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public void UpdateBook_ShouldReturn_200Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.bookUpdateDetail(BookMockdata.updateBookdatabyBookid())).Returns(BookMockdata.updateBookdatabyBookidResponse());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = sut.UpdateBook(BookMockdata.updateBookdatabyBookid());

            //Assert
            object p = result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public void UpdateBook_ShouldReturn_400Status()
        {
            // Arrange

            var bookService = new Mock<IBookService>();
            bookService.Setup(x => x.bookUpdateDetail(BookMockdata.AddbookValuebyEmpty())).Returns(BookMockdata.EmptyResponseMessage());
            var sut = new BookMasterController(bookService.Object);
            //Act
            var result = sut.UpdateBook(BookMockdata.AddbookValuebyEmpty());

            //Assert
            object p = result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
    }
}
