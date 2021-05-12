using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data.Repositories
{
    public interface ICourseRepository: IRepositoryBase<Course, int>
    {
    }

    public interface ICourseReadOnlyRepository : IReadOnlyRepository<Course, int>
    {
    }

    public interface IProfessorRepository
    {

    }

    public interface IStudentRepository
    {

    }

    public class ProfessorRepository:IProfessorRepository
    { //CODE HERE
    }

    public class StudentRepository : IStudentRepository
    { //CODE HERE
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
}
