using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private int IdCounter = 1;
        private List<Book> books;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = IdCounter++,
                Title = "Game of Thrones",
                Language = "English",
                Author = "George R. R. Martin"
            });

            books.Add(new Book
            {
                Id = IdCounter++,
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
            try
            {
                return books.Single(book => book.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public void Post(Book value)
        {
            value.Id = IdCounter++;
            books.Add(value);
        }

        public void Put(int id, Book value)
        {
            value.Id = id;
            var toUpdateBookIndex = books.FindIndex(book => book.Id == id);
            if(Get(toUpdateBookIndex) != null)
            {
                Console.WriteLine(toUpdateBookIndex);
                books[toUpdateBookIndex] = value;
            }
        }

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
