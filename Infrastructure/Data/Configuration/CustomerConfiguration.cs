using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Customer");

            builder.HasOne(p=>p.Person)
            .WithMany(p=>p.Customers)
            .HasForeignKey(p => p.IdPersonFK ); 

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(30);      

        }
    }
}