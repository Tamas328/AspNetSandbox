using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox
{
    public class BooksServiceTests
    {
        [Fact]
        public void BooksServiceTest()
        {
            // Assume
            var booksService = new BooksService();

            // Act
            booksService.AddBook(new Book
            {
                Title = "Test Book Nr.1",
                Author = "Jack 1",
                Language = "English"
            });
            booksService.DeleteBook(2);
            booksService.AddBook(new Book
            {
                Title = "Test Book Nr.2",
                Author = "Jack 2",
                Language = "English"
            });

            // Assert
            Assert.Equal("Test Book Nr.1", booksService.GetBook(3).Title);
        }
    }
}
