using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course, int>
    {
    }

    public interface ICourseReadOnlyRepository : IReadOnlyRepository<Course, int>
    {
    }

    public interface IProfessorReadOnlyRepository : IReadOnlyRepository<Professor, int>
    {

    }

    public interface IStudentReadOnlyRepository : IReadOnlyRepository<Student, int>
    {

    }

    public interface IProfessorRepository : IRepositoryBase<Professor, int>
    {

    }

    public interface IStudentRepository : IRepositoryBase<Student, int>
    {

    }

    public class ProfessorRepository: RepositoryBase<Professor, int>, IProfessorRepository
    {
        public ProfessorRepository(SchoolDbContext context) : base(context)
        {
        }
    }

    public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context) : base(context)
        {
        }
    }

    public class CourseRepository : RepositoryBase<Course, int>, ICourseRepository
    {
        public CourseRepository(SchoolDbContext context): base(context)
        {
        }
    }

    public class CourseReadOnlyRepository : ReadOnlyRepositoryBase<Course, int>, ICourseReadOnlyRepository
    {
        public CourseReadOnlyRepository(SchoolDbContext context) : base(context)
        {
        }
    }

    public class ProfessorReadOnlyRepository : ReadOnlyRepositoryBase<Professor, int>, IProfessorReadOnlyRepository
    {
        public ProfessorReadOnlyRepository(SchoolDbContext context) : base(context)
        {
        }
    }

    public class StudentReadOnlyRepository : ReadOnlyRepositoryBase<Student, int>, IStudentReadOnlyRepository
    {
        public StudentReadOnlyRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
