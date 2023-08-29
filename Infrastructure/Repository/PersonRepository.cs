
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly AutoRepairContext _context;

        public PersonRepository(AutoRepairContext context) : base(context)
        {
            this._context = context;
        }

    public Task ToListAsync()
        {
            throw new NotImplementedException();
        }

    public override async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.People
            .Include(p => p.Customers)
            .Include(p => p.Employees)
            .ToListAsync();
    }

    public override async Task<Person> GetByIdAsync(int id)
    {
        return await _context.People
            .Include(p => p.Customers)
            .Include(p => p.Employees)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    }

}