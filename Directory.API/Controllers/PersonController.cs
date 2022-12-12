using AutoMapper;
using Directory.API.DTOs;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;
using Directory.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IUnitOfWork _repository;
        private IMapper _mapper;

        public PersonController(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            var people = _repository.PersonRepository.Get(x => x.Id == Guid.Empty);
            return Ok(people);
        }

        [HttpPost]
        public ActionResult<Person> AddPerson([FromBody] PersonDTO personDto)
        {
            if (personDto is null)
                return BadRequest("PERSON_OBJECT_IS_NULL");
            if (!ModelState.IsValid)
                return BadRequest("INVALID_OBJECT");

            Person person = _mapper.Map<Person>(personDto);
            _repository.PersonRepository.Add(person);
            _repository.Commit();
            return Ok(person);

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody] PersonDTO personDto)
        {
            if (personDto is null)
                return BadRequest("PERSON_OBJECT_IS_NULL");
            if (!ModelState.IsValid)
                return BadRequest("INVALID_OBJECT");

            Person person = _repository.PersonRepository.Get(x => x.Id == id);

            if (person is null)
            {
                return NotFound();
            }
            _mapper.Map(personDto, person);
            _repository.PersonRepository.Update(person);
            _repository.Commit();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(Guid id)
        {
            Person person = _repository.PersonRepository.Get(x => x.Id == id);
            if (person == null)
                return NotFound();
            _repository.PersonRepository.Remove(person);
            _repository.Commit();
            return NoContent();
        }
    }
}
