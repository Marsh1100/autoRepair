using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Employee");

            builder.HasOne(p=>p.Person)
            .WithMany(p=>p.Employees)
            .HasForeignKey(p => p.IdPersonFK ); 

            builder.Property(p => p.Specialty1)
            .IsRequired()
            .HasMaxLength(30);    
        }
    }
}