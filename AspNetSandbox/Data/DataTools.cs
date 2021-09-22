using AspNetSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Data
{
    public static class DataTools
    {
        public static string connectionString = null;

        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there.");
                }
                else
                {
                    applicationDbContext.Add(new Book {
                        Id = 1,
                        Title = "Harry Potter and the Goblet of Fire",
                        Author = "JK Rowling",
                        Language = "English",
                        PurchasePrice = 50,
                    });
                    Console.WriteLine("Added book with title: Harry Potter and the Goblet of Fire");
                    applicationDbContext.Add(new Book {
                        Id = 2,
                        Title = "The Happiest Man on Earth",
                        Author = "Eddie Jaku",
                        Language = "English",
                        PurchasePrice = 35,
                    });
                    Console.WriteLine("Added book with title: The Happiest Man on Earth");
                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}
