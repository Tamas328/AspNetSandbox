using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksService
    {
        void DeleteBook(int id);
        Book GetBook(int id);
        void AddBook(Book value);
        void UpdateBook(int id, Book value);
        IEnumerable<Book> GetBooks();
    }
}