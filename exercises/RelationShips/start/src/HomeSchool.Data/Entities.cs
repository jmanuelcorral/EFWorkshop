using System;
using System.Collections.Generic;

namespace HomeSchool.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int ProfessorId { get; set; }
        public Professor professor { get; set; }
        public IList<Student> Students { get; set; }
        public bool isComplete => (Students?.Count >= 22);
    }

    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTimeOffset startDate { get; set; }
        public bool IsSenior => (DateTime.UtcNow.Year - startDate.Year) > 1;
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }

    public class Professor
    {
        public int Id { get; set; }
        public string ProfessorName { get; set; }
        public DateTimeOffset startDate { get; set; }
        public bool IsSenior => (DateTime.UtcNow.Year - startDate.Year) > 1;
        public IList<Course> Courses { get; set; }
    }
}
