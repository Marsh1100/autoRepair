using API.Dtos;
using API.Controllers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PersonController : BaseApiController
{
   /* private readonly AutoRepairContext _context;
   // private readonly IMapper mapper;

    public PersonController(AutoRepairContext context)
    {
        _context = context;
        //_mapper = mapper;
    }*/

    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PersonController(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        this.unitOfWork = _unitOfWork;
        this.mapper = _mapper;
    }

    [HttpGet]
    // [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var people = await  unitOfWork.People.GetAllAsync();
        return mapper.Map<List<PersonDto>>(people);
    }

   /* [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var person = await unitOfWork.People.FindAsync(id);
        return Ok(person);
    }*/


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var person = await unitOfWork.People.GetByIdAsync(id);
        if(person == null)
        {
            return NotFound();
        }
        return mapper.Map<PersonDto>(person);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(PersonDto personDto){
        var person = this.mapper.Map<Person>(personDto);
        this.unitOfWork.People.Add(person);
        await unitOfWork.SaveAsync();
        if (person == null)
        {
            return BadRequest();
        }
        personDto.Id = person.Id;
        return CreatedAtAction(nameof(Post),new {id= personDto.Id}, personDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Put(int id, [FromBody]PersonDto personDto){
        if(personDto == null)
            return NotFound();
        var person = this.mapper.Map<Person>(personDto);
        unitOfWork.People.Update(person);
        await unitOfWork.SaveAsync();
        return personDto;
        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var person = await unitOfWork.People.GetByIdAsync(id);
        if(person == null){
            return NotFound();
        }
        unitOfWork.People.Remove(person);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    
}
