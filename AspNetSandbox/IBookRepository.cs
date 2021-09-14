using System.Collections.Generic;
using AspNetSandbox.Models;

namespace AspNetSandbox
{
    public interface IBookRepository
    {
        void DeleteBook(int id);

        Book GetBook(int id);

        void AddBook(Book value);

        void UpdateBook(int id, Book value);

        IEnumerable<Book> GetBooks();
    }
}