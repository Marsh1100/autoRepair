using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IPerson People { get; }
    ICustomer Customers { get; }
    // ITypePerson TypePersons{ get; }
    // IRegion Regions {get; }

    Task<int> SaveAsync();
}
