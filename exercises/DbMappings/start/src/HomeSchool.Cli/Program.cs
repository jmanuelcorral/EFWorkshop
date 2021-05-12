using HomeSchool.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeSchool.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            var generator = new DataGenerator();
            var myData = generator.GenerateCourses(100).ToArray();
            var connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=schooldb;Integrated Security=SSPI;";
            using (var myContext = new SchoolDbContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)) 
            {
                myContext.Database.EnsureCreated(); //This Deletes your database everytime you enter here
                myContext.Courses.AddRange(myData);
                myContext.SaveChanges();
           }

                Console.WriteLine("DataGenerated, press [enter] to exit");
            Console.ReadLine();
        }
    }
}
