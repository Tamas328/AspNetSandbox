using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetSandbox.Models;
using AspNetSandbox.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(repository.GetBooks());
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(repository.GetBook(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>

        /// <summary>
        /// Adds a new Book object.
        /// </summary>
        /// <param name="book">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                return Ok();
            } 
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5

        /// <summary>
        /// Updates a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            repository.UpdateBook(id, book);
            return Ok();
        }

        // DELETE api/<BooksController>/5

        /// <summary>
        /// Deletes a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
    }
}
