using authtestAdavila.Models;
using authtestAdavila.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authtestAdavila.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(Policy = "AllUsers")]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "ClientOnly")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Add(Book book)
        {
            _bookService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();
            _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
