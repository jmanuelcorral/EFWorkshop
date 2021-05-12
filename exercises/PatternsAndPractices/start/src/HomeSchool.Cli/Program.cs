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
                myContext.Database.EnsureDeleted();
                myContext.Database.EnsureCreated();
                myContext.Courses.AddRange(myData);
                myContext.SaveChanges();

                //UnComment These lines for test your exercise
                /*
                var professorWithMoreThanOneCourse = myContext.Professors.Include(x => x.Courses).Where(x=> x.Courses.Count>1).ToList();
                var projectionResults = professorWithMoreThanOneCourse.Select(x => new { ProfessorName = x.ProfessorName, CourseNames = string.Join(",", x.Courses.Select(y => y.CourseName)) });
                Console.WriteLine("");
                Console.WriteLine("Results of the queries are:");
                string result = projectionResults.DumpAsJson();
                Console.WriteLine(result);
                */
                
           }

                Console.WriteLine("DataGenerated, press [enter] to exit");
            Console.ReadLine();
        }
    }
}
