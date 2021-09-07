using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksService
    {
        void Delete(int id);
        Book Get(int id);
        void Post(Book value);
        void Put(int id, string value);
        IEnumerable<Book> Get();
    }
}