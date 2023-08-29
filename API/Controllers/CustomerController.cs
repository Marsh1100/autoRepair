using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIstore.Controllers;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class CustomerController : BaseApiController
    {
        private readonly AutoRepairContext _context;
        
        public CustomerController(AutoRepairContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        
    }
