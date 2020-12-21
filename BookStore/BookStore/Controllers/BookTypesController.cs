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
using BookStore.ApplicationLogic;
using BookStore.DTO;
namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {


        private readonly IBookTypeApplicationLogic _bookTypeApplicationLogic;
        
        public BookTypesController(IBookTypeApplicationLogic bookTypeApplicationLogic)
        {
            _bookTypeApplicationLogic = bookTypeApplicationLogic;
        }

        // GET: api/getbooktypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTypeDTO>>> GetBookTypes()
        {
            try
            {
                return Ok(await _bookTypeApplicationLogic.getBookTypes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/booktypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookTypeDTO>> GetBookType(int id)
        {
            try
            {
                var result = await _bookTypeApplicationLogic.getBookType(id);

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
        public async Task<ActionResult<BookType>> PutBookType(int id, BookTypeDTO booktype)
        {
            if (id != booktype.BookTypeId)
            {
                return BadRequest();
            }

            return await _bookTypeApplicationLogic.updateBookType(booktype);

           
        }

        // POST: api/booktypes
   
        [HttpPost]
        public async Task<ActionResult<BookType>> PostBookType(BookTypeDTO bookType)
        {
            try
            {
                if (bookType == null)
                    return BadRequest();

                var createdBookType = await _bookTypeApplicationLogic.addBookType(bookType);

                return CreatedAtAction(nameof(GetBookType),
                    new { id = createdBookType.BookTypeId }, createdBookType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new book type record");
            }
        }
       
    }
}