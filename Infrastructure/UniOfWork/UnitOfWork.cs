
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;


//IDisposable es una interfaz de .NET
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AutoRepairContext context;
    private PersonRepository _people;
    public UnitOfWork(AutoRepairContext _context)
    {
        context = _context;
    }

    public IPerson People
    {
        get{
            if(_people == null){
                _people = new PersonRepository(context);
            }
            return _people;
        }
    }

    public void Dispose()
    {
        //throw new NotImplementedException();
        context.Dispose();
        
    }
    public  Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
    
}