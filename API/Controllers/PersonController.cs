

using APIstore.Controllers;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PersonController : BaseApiController
{
    private readonly AutoRepairContext _context;
    
    public PersonController(AutoRepairContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        var people = await _context.People.ToListAsync();
        return Ok(people);
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
