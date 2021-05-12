using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data
{
    public class SchoolDbContext: DataContext
    {
        private readonly int MaxLenghtInNames = 250;

        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }


    }
}
