using AutoMapper;
using Directory.API.DTOs;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Contact.API.Controllers;

[Route("api/{personId:int}/[controller]")]
[ApiController]
public class InformationController : ControllerBase
{
    private IUnitOfWork _repository;
    private IMapper _mapper;
    public InformationController(IUnitOfWork repository, IMapper mapper)
    {
        _repository ??= repository;
        _mapper ??= mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Information>> GetInformations(Guid personId)
    {
        IEnumerable<Information> informations = _repository.InformationRepository.GetAll(x => x.Id == personId);
        return Ok(informations);
    }

    [HttpPost]
    public ActionResult<Information> CreateInfo(Guid personId, [FromBody] InformationDTO infoDto)
    {

        if (infoDto is null)
            return BadRequest("INFORMATION_OBJECT_IS_NULL");
        if (!ModelState.IsValid)
            return BadRequest("INVALID_OBJECT");

        Information information = _mapper.Map<Information>(infoDto);
        information.PersonId = personId;
        _repository.InformationRepository.Add(information);
        _repository.Commit();
        return Ok(information);

    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateInfo(int personId, int id, [FromBody] InformationDTO infoDto)
    {
        if (infoDto is null)
            return BadRequest("INFORMATION_OBJECT_IS_NULL");
        if (!ModelState.IsValid)
            return BadRequest("INVALID_OBJECT");

        Information information = _repository.InformationRepository.Get(x => x.Id == Guid.Empty);

        if (information is null)
            return NotFound();

        _mapper.Map(infoDto, information);
        _repository.InformationRepository.Update(information);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePerson(Guid id)
    {
        Information information = _repository.InformationRepository.Get(x => x.Id == id);
        if (information is null)
            return NotFound();
        _repository.InformationRepository.Remove(information);
        _repository.Commit();
        return NoContent();
    }
}
