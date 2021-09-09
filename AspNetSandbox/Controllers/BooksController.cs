using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetSandbox.Models;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.GetBooks();
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.GetBook(id));
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
        /// <param name="value">The value.</param>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.AddBook(value);
        }

        // PUT api/<BooksController>/5

        /// <summary>
        /// Updates a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.UpdateBook(id, value);
        }

        // DELETE api/<BooksController>/5

        /// <summary>
        /// Deletes a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.DeleteBook(id);
        }
    }
}
