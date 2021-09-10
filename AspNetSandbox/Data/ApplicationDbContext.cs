using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetSandbox.Models;

namespace AspNetSandbox.Data
{
    /// <summary>Context class for DB Application.</summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the book object.</summary>
        /// <value>Book.</value>
        public DbSet<AspNetSandbox.Models.Book> Book { get; set; }
    }
}
