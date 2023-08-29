using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Person");

            builder.Property(p => p.IdPerson)
            .IsRequired()
            .HasMaxLength(20);     

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);   
        }

       
    }
}