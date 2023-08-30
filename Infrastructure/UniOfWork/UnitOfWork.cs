
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;


//IDisposable es una interfaz de .NET
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AutoRepairContext context;
    public UnitOfWork(AutoRepairContext _context)
    {
        context = _context;
    }
    private PersonRepository _people;
    
    public IPerson People
    {
        get{
            if(_people == null){
                _people = new PersonRepository(context);
            }
            return _people;
        }
    }

    private CustomerRepository _customers;
    
    public ICustomer Customers
    {
        get{
            if(_customers == null){
                _customers = new CustomerRepository(context);
            }
            return _customers;
        }
    }

    public void Dispose()
    {
        //throw new NotImplementedException();
        context.Dispose();
        
    }
    public async Task<int> SaveAsync()
    {
       // throw new NotImplementedException();

       //YS
       return await context.SaveChangesAsync();
    }
    
}