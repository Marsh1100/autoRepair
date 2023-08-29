

using API.Dtos;
using APIstore.Controllers;
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

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    //[MapToApiVersion()]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Get()  //Se cambia Person ---> PersonDto
    {
        var people = await .People.ToListAsync();
        return Ok(people);
        //return mapper.Map<List<PersonDto>>(people); //--> Se cambia el return (para poder visualizar los tipo de personas)
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var person = await _context.People.FindAsync(id);
        return Ok(person);
    }


    
}
