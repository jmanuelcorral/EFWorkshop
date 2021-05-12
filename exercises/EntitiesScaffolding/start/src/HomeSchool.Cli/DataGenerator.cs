using Bogus;
using HomeSchool.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Cli
{
    //You like Bogus FAKER? https://github.com/bchavez/Bogus
    //another option is to use one service as https://www.mockaroo.com/

    public class DataGenerator
    {
        private readonly string[] _courseNames = new[] { "Maths", "Calculus", "Story", "Science" };
        private readonly DateTime _startingDates = DateTime.UtcNow.AddYears(-5);
        private readonly DateTime _endingDates = DateTime.UtcNow;
        private readonly int _defaultNumberOfProfessors = 50;
        private readonly int _defaultNumberOfStudentsPerClass = 25;

      
        private IList<Professor> GenerateProfessors(int numberOfRecords)
        {
            var ids = 1;
            var professorCollection = new Faker<Professor>()
            
            //.RuleFor(m => m.Id, f => ids++)
            .RuleFor(m => m.ProfessorName, f => f.Person.FullName)
            .RuleFor(m => m.startDate, f => f.Date.Between(_startingDates, _endingDates));

            return professorCollection.Generate(numberOfRecords);
        }

        private IList<Student> GenerateStudents(int numberOfRecords)
        {
            var ids = 1;
            var studentCollection = new Faker<Student>()

            //.RuleFor(m => m.Id, f => ids++)
            .RuleFor(m => m.StudentName, f => f.Person.FullName)
            .RuleFor(m => m.startDate, f => f.Date.Between(_startingDates, _endingDates));

            return studentCollection.Generate(numberOfRecords);
        }

        public IList<Course> GenerateCourses(int numberOfRecords)
        {
            var ids = 1;
            var professors = GenerateProfessors(_defaultNumberOfProfessors);
            var coursesCollection = new Faker<Course>()
            //.RuleFor(m => m.Id, f => ids++)
            .RuleFor(m => m.CourseName, f => f.PickRandom(_courseNames))
            .RuleFor(m => m.professor, f=> f.PickRandom<Professor>(professors))
            .RuleFor(m => m.Students, f => GenerateStudents(_defaultNumberOfStudentsPerClass));

            var records = coursesCollection.Generate(numberOfRecords);
            Console.WriteLine(records.DumpAsJson());
            return records;
        }
    }
}
