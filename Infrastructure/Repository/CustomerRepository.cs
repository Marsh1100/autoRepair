using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomer
    {
        private readonly AutoRepairContext _context;
        public CustomerRepository(AutoRepairContext context) : base(context)
        {
            this._context = context;
        }

   public override async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync(); //En el caso de que las tablas no esten relacionadas...con otras
           
    }
   public override async Task<Customer> GetByIdAsync(int id)
    {
        return await  _context.Customers.FindAsync(id);
    }
    }
}