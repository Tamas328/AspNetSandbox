using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = books.Count + 1,
                Title = "Game of Thrones",
                Language = "English",
                Author = "George R. R. Martin"
            });

            books.Add(new Book
            {
                Id = books.Count + 1,
                Title = "Deep Work",
                Language = "English",
                Author = "Cal Newport"
            });
        }
        public IEnumerable<Book> Get()
        {
            return books;
        }
        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void Post(Book value)
        {
            value.Id = books.Count + 1;
            books.Add(value);
        }

        public void Put(int id, string value)
        {

        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
