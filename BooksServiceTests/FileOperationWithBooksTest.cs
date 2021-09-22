using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BooksServiceTests
{
    public class FileOperationWithBooksTest
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("newSettings.json", @"{
  ""ConnectionStrings"": {
    ""DefaultConnection"": ""Port=5432; Database=SandboxDb; Host=localhost; User Id=postgres; Trust Server Certificate=true"",
    ""Heroku"": ""Port=5432; Database=d4ne7vk964ctvm; Host=ec2-52-214-178-113.eu-west-1.compute.amazonaws.com; User Id=ahcuwuuytkwcex; Password=ca6592f21955b266e2f2cebd75ef2117a438314beb66fe1c93bc58bc8ff95c95; SSL Mode=Require; Trust Server Certificate=true""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft"": ""Warning"",
      ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
        }

        [Fact]
        public void ReadFilesTest()
        {
            using (FileStream fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var returnedString = temp.GetString(b);
                    Console.WriteLine(returnedString);
                }
            }
        }
    }
}
