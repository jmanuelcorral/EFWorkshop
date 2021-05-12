using HomeSchool.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSchool.Data.UnitOfWork
{
    public interface ISchoolUnitOfWork:IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentRepository StudentRepository { get; }
    }

    public class SchoolUnitOfWork: UnitOfWork, ISchoolUnitOfWork
    {
        public ICourseRepository CourseRepository { get; private set; }
        public IProfessorRepository ProfessorRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }

        public SchoolUnitOfWork(SchoolDbContext context, 
            ICourseRepository courseRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository): base(context)
        {
            CourseRepository = courseRepository;
            ProfessorRepository = professorRepository;
            StudentRepository = studentRepository;
        }
    }
}
