using AspNetSandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksServiceTests
{
    public class StartupTests
    {
        [Fact]
        public void CheckConversionToEfConnectionString()
        {
            // Assume
            string databaseUrl = "postgres://ahcuwuuytkwcex:ca6592f21955b266e2f2cebd75ef2117a438314beb66fe1c93bc58bc8ff95c95@ec2-52-214-178-113.eu-west-1.compute.amazonaws.com:5432/d4ne7vk964ctvm";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            // Assert
            Assert.Equal("Port=5432; Database=d4ne7vk964ctvm; Host=ec2-52-214-178-113.eu-west-1.compute.amazonaws.com; User Id=ahcuwuuytkwcex; Password=ca6592f21955b266e2f2cebd75ef2117a438314beb66fe1c93bc58bc8ff95c95; SSL Mode=Require; Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
