using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Car");

            builder.HasOne(p=>p.Customer)
            .WithMany(p=>p.Cars)
            .HasForeignKey(p => p.IdCustomerFK ); 

            builder.Property(p => p.CarPlate)
            .IsRequired()
            .HasMaxLength(10); 

            builder.Property(p => p.Model)
            .IsRequired()
            .HasMaxLength(4);        
        }
    }
}