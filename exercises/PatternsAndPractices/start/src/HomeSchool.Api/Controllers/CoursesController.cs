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
    public class CoursesController : ControllerBase
    {
        private readonly ISchoolUnitOfWork _uoW;
        private readonly ICourseReadOnlyRepository _readonlyRepo;
        public CoursesController(ISchoolUnitOfWork uow, ICourseReadOnlyRepository repoCourseReadOnly)
        {
            _uoW = uow;
            _readonlyRepo = repoCourseReadOnly;
        }

        
        [HttpGet]
        public async Task<IList<Course>> Get()
        {
            return await _readonlyRepo.Get();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var myResult = await _readonlyRepo.GetById(id);
            if (myResult.HasNoValue)
                return NotFound();
            else return Ok(myResult.Value);
        }

        
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Course course)
        {
            _uoW.CourseRepository.Add(course);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok(course.Id);
            return BadRequest();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Course value)
        {
            var course = await _uoW.CourseRepository.GetById(id);
            if (course.HasValue)
            {
                course.Value.CourseName = value.CourseName;
                _uoW.CourseRepository.Update(course.Value);
                var isSaved = await _uoW.SaveChangesAsync();
                if (isSaved)
                    return Ok();
            }
            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _uoW.CourseRepository.Remove(id);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok();
            return NotFound();
        }
    }
}
