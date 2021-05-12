using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data
{
    public class SchoolDbContext: DbContext
    {
        private readonly int MaxLenghtInNames = 250;

        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Ignore(x => x.IsSenior);
            modelBuilder.Entity<Student>().Property(x => x.StudentName).HasColumnName("Name").HasMaxLength(MaxLenghtInNames);
            modelBuilder.Entity<Professor>().Property(x => x.ProfessorName).HasColumnName("Name").HasMaxLength(MaxLenghtInNames);
            modelBuilder.Entity<Professor>().Ignore(x => x.IsSenior);
            modelBuilder.Entity<Course>().Ignore(x => x.isComplete);
            modelBuilder.Entity<Course>().Property(x => x.CourseName).HasColumnName("Name").HasMaxLength(MaxLenghtInNames);

            //Add here your mapping setup for relationships

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }


    }
}
