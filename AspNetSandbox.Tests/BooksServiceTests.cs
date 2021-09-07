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
            booksService.Post(new Book
            {
                Title = "Test Book Nr.1",
                Author = "Jack 1",
                Language = "English"
            });
            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "Test Book Nr.2",
                Author = "Jack 2",
                Language = "English"
            });

            // Assert
            Assert.Equal("Test Book Nr.1", booksService.Get(3).Title);
        }
    }
}
