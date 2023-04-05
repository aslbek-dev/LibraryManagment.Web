
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Services.Foundations.Books;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace LibraryManagment.Api.Controllers;
[ApiController]
[Route("api/[controller]")]


    public class BooksController : RESTFulController
    {
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Book>> PostBookAsync(Book book)
        {
            try
            {
                return await this.bookService.AddBookAsync(book);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
