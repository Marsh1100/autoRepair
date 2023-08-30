using API.Dtos;
using API.Controllers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CustomerController : BaseApiController
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

    public CustomerController(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        this.unitOfWork = _unitOfWork;
        this.mapper = _mapper;
    }

    [HttpGet]
    // [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        var customers = await  unitOfWork.Customers.GetAllAsync();
        return mapper.Map<List<CustomerDto>>(customers);
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
    public async Task<ActionResult<CustomerDto>> Get(int id)
    {
        var customer = await unitOfWork.Customers.GetByIdAsync(id);
        if(customer == null)
        {
            return NotFound();
        }
        return mapper.Map<CustomerDto>(customer);
    }


    
}
