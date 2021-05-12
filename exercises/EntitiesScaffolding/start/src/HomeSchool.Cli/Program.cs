using System;

namespace HomeSchool.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            var generator = new DataGenerator();
            var myData = generator.GenerateCourses(100);
            //Add Here your DbContext initalization and Seeding
            //You can inject myData in the Database

            Console.WriteLine("DataGenerated, press [enter] to exit");
            Console.ReadLine();
        }
    }
}
