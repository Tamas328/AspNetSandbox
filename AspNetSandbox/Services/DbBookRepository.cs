using AspNetSandbox.Data;
using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Services
{
    public class DbBookRepository : IBookRepository 
    {
        private readonly ApplicationDbContext context;

        public DbBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddBook(Book book)
        {
            this.context.Add(book);
            this.context.SaveChangesAsync();
        }

        public void DeleteBook(int id)
        {
            var book = this.context.Book.Find(id);
            this.context.Book.Remove(book);
            this.context.SaveChangesAsync();
        }

        public Book GetBook(int id)
        {
            var book = this.context.Book.FirstOrDefault(m => m.Id == id);
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return this.context.Book.ToList();
        }

        public void UpdateBook(int id, Book book)
        {
            this.context.Update(book);
            this.context.SaveChanges();
        }
    }
}
