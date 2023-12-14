using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _dbContext.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
                 if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (book == null)
            {
                return BadRequest();
            }

            var addedBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);

            if (addedBook != null)
            {
                return BadRequest("Book already exists");
            }
            else
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Author = updatedBook.Author;

            _dbContext.Books.Update(existingBook);
            await _dbContext.SaveChangesAsync();

            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
