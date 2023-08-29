
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Person : BaseEntity
{
    public string IdPerson { get; set;}
    public string Name { get; set; }
    //public string LastName { get; set; }
    //public string PhoneNumber { get; set; }

    public ICollection<Customer> Customers { get; set; } 
    public ICollection<Employee> Employees { get; set; } 

}
