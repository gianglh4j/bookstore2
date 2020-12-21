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

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        

        private readonly IBookTypeRepository _bookTypeRepository;
        public BookTypesController(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }

        // GET: api/getbooktypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookType>>> GetBookTypes()
        {
            try
            {
                return Ok(await _bookTypeRepository.GetBookTypes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/booktypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookType>> GetBookType(int id)
        {
            try
            {
                var result = await _bookTypeRepository.GetBookType(id);

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
        public async Task<ActionResult<BookType>> PutBookType(int id, BookType booktype)
        {
            try
            {
                if (id != booktype.BookTypeId)
                    return BadRequest("booktype ID mismatch");

                var booktypeToUpdate = await _bookTypeRepository.GetBookType(id);

                if (booktypeToUpdate == null)
                    return NotFound($"book type with Id = {id} not found");

                return await _bookTypeRepository.UpdateBookType(booktype);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/booktypes
   
        [HttpPost]
        public async Task<ActionResult<BookType>> PostBookType(BookType bookType)
        {
            try
            {
                if (bookType == null)
                    return BadRequest();

                var createdBookType = await _bookTypeRepository.AddBookType(bookType);

                return CreatedAtAction(nameof(GetBookType),
                    new { id = createdBookType.BookTypeId }, createdBookType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book type record");
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookType>> DeleteBookType(int id)
        {
            try
            {
                var bookTypeToDelete = await _bookTypeRepository.GetBookType(id);

                if (bookTypeToDelete == null)
                {
                    return NotFound($"book type with Id = {id} not found");
                }

                return await _bookTypeRepository.DeleteBookType(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

       
    }
}