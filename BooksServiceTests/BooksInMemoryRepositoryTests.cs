using AspNetSandbox.Models;
using AspNetSandbox.Services;
using Xunit;

namespace AspNetSandbox.Data
{
    public class BooksInMemoryRepositoryTests
    {
        [Fact]
        public void BooksServiceAddDeleteTest()
        {
            // Assume
            var booksService = new BooksInMemoryRepository();

            // Act
            booksService.AddBook(new Book
            {
                Title = "Harry Potter and the Goblet of Fire",
                Author = "JK Rowling",
                Language = "English",
            });
            booksService.DeleteBook(2);
            booksService.AddBook(new Book
            {
                Title = "The Happiest Man on Earth",
                Author = "Eddie Jaku",
                Language = "English",
            });

            // Assert
            Assert.Equal("Harry Potter and the Goblet of Fire", booksService.GetBook(3).Title);
        }

        [Fact]
        public void BookServiceUpdateTest()
        {
            // Assume
            var booksService = new BooksInMemoryRepository();

            // Act
            booksService.UpdateBook(2, new Book
            {
                Title = "Funky Business",
                Author = "Jonas Ridderstrale",
                Language = "English",
            });

            // Assert
            Assert.Equal("Funky Business", booksService.GetBook(2).Title);
        }
    }
}
