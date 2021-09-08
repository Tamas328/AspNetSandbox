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
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }
        public Book GetBook(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void AddBook(Book value)
        {
            value.Id = IdCounter++;
            books.Add(value);
        }

        public void UpdateBook(int id, Book value)
        {
            value.Id = id;
            var toUpdateBookIndex = books.FindIndex(_ => _.Id == id);
            if (GetBook(id) != null)
            {
                books[toUpdateBookIndex] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBook(id));
        }
    }
}
