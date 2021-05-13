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
    public class ProfessorController : ControllerBase
    {
        private readonly ISchoolUnitOfWork _uoW;
        private readonly IProfessorReadOnlyRepository _readonlyRepo;
        public ProfessorController(ISchoolUnitOfWork uow, IProfessorReadOnlyRepository repoCourseReadOnly)
        {
            _uoW = uow;
            _readonlyRepo = repoCourseReadOnly;
        }

        
        [HttpGet]
        public async Task<IList<Professor>> Get()
        {
            return await _readonlyRepo.Get();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> Get(int id)
        {
            var myResult = await _readonlyRepo.GetById(id);
            if (myResult.HasNoValue)
                return NotFound();
            else return Ok(myResult.Value);
        }

        
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Professor value)
        {
            _uoW.ProfessorRepository.Add(value);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok(value.Id);
            return BadRequest();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Professor value)
        {
            var professor = await _uoW.ProfessorRepository.GetById(id);
            if (professor.HasValue)
            {
                professor.Value.ProfessorName = value.ProfessorName;
                _uoW.ProfessorRepository.Update(professor.Value);
                var isSaved = await _uoW.SaveChangesAsync();
                if (isSaved)
                    return Ok();
            }
            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _uoW.ProfessorRepository.Remove(id);
            var isSaved = await _uoW.SaveChangesAsync();
            if (isSaved)
                return Ok();
            return NotFound();
        }
    }
}
