
using System.Reflection;
using Core.Entities; 
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AutoRepairContext : DbContext
{
    public AutoRepairContext(DbContextOptions<AutoRepairContext> options) : base(options)
    {
    }

    public DbSet<Person> People {get; set;}
    public DbSet<Customer> Customers {get; set;}
    public DbSet<Employee> Employees {get; set;}

    /*public Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<global::API.Dtos.PersonDto>> Map<T>(List<Person> people)
    {
        throw new NotImplementedException();
    }*/

    //Sobrecarga que toma los modelos que se han definido en configuración
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}