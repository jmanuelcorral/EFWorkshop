using HomeSchool.Data;
using HomeSchool.Data.Repositories;
using HomeSchool.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSchool.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ISchoolUnitOfWork _uoW;
        private readonly IStudentReadOnlyRepository _readonlyRepo;
        public StudentController(ISchoolUnitOfWork uow, IStudentReadOnlyRepository repoCourseReadOnly)
        {
            _uoW = uow;
            _readonlyRepo = repoCourseReadOnly;
        }

        
        [HttpGet]
        public async Task<IList<Student>> Get()
        {
            return await _readonlyRepo.Get();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var myResult = await _readonlyRepo.GetById(id);
            if (myResult.HasNoValue)
                return NotFound();
            else return Ok(myResult.Value);
        }

        
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Student course)
        {
            _uoW.StudentRepository.Add(course);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok(course.Id);
            return BadRequest();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Student value)
        {
            var student = await _uoW.StudentRepository.GetById(id);
            if (student.HasValue)
            {
                student.Value.StudentName = value.StudentName;
                _uoW.StudentRepository.Update(student.Value);
                var isSaved = await _uoW.SaveChangesAsync();
                if (isSaved)
                    return Ok();
            }
            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _uoW.StudentRepository.Remove(id);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok();
            return NotFound();
        }
    }
}
