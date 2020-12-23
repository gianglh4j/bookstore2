using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Data;
using BookStore.Repository;
using System;
using Microsoft.AspNetCore.Http;
using BookStore.DTO;
using BookStore.ApplicationLogic;
using BookStore.DomainLogic;
using Contracts;
using BookStore.CustomExceptionMiddleware;
namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        

       
        private readonly IBookApplicationLogics _bookApplicationLogics;
        private readonly ILoggerManager _logger;
        public BooksController( IBookApplicationLogics bookApplicationLogics, ILoggerManager logger)
        {
            
            _bookApplicationLogics = bookApplicationLogics;
            _logger = logger;

        }
        [HttpGet("types/{id}")]
        public async Task<ActionResult<IEnumerable<BookDTORes>>> GetBookFollowType(int id)
        {
            return Ok(await _bookApplicationLogics.getBooksFollowType(id));
        }
        // GET: api/getbooks
        [HttpGet]
       
        public async Task<ActionResult> GetBooks()
        {
           
                _logger.LogInfo("Here is info message from the controller.");

            var books = Ok(await _bookApplicationLogics.getBooks());
            throw new KeyNotFoundException("Exception while fetching all the books from the storage.");
            return books;



        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BookDTORes>>> GetBooks()
        //{

        //    _logger.LogInfo("Here is info message from the controller.");

        //    var books = Ok(await _bookApplicationLogics.getBooks());
        //    throw new KeyNotFoundException("Exception while fetching all the books from the storage.");
        //    return books;



        //}

        // GET: api/booktypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTORes>> GetBook(int id)
        {
            try
            {
                var result = await _bookApplicationLogics.getBook(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT: api/booktypes/5
       
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, BookDTO book)
        {
            try
            {
                
                if (id != book.BookId)
                    return BadRequest("book ID mismatch");



                // set book from bookDTO 
                var updatedbook = await _bookApplicationLogics.updateBook(book);
                return updatedbook;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/book
   
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO book)
        {
            
            try
            {

                if (book == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                   "record is space");
                }

                var createdBook = await _bookApplicationLogics.addBook(book);

                return CreatedAtAction(nameof(GetBook),
                    new { id = createdBook.BookId }, createdBook);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book  record");
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(BookDTO book)
        {
            try
            {
             
                var updatedbook = await _bookApplicationLogics.deleteBook(book);
                return updatedbook;
                //var bookToDelete = await _bookRepository.GetBook(id);

                //if (bookToDelete == null)
                //{
                //    return NotFound($"book  with Id = {id} not found");
                //}

                //return await _bookRepository.DeleteBook(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

       
    }
}