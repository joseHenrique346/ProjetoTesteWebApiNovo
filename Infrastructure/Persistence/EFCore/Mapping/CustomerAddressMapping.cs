using Infrastructure.Persistence.EFCore.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFCore.Mapping
{
    public class CustomerAddressMapping : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(i => i.Id).HasName("id");

            builder.Property(i => i.PostalCode).HasColumnName("cep");
            builder.Property(i => i.PostalCode).IsRequired();
            builder.Property(i => i.PostalCode).HasMaxLength(8);

            builder.Property(i => i.Number).HasColumnName("numero");
            builder.Property(i => i.Number).IsRequired();

            builder.Property(i => i.Reference).HasColumnName("referencia");
            builder.Property(i => i.Reference).HasMaxLength(100);

            builder.Property(i => i.Complement).HasColumnName("complemento");
            builder.Property(i => i.Complement).HasMaxLength(100);

            builder.Property(i => i.Neighborhood).HasColumnName("bairro");
            builder.Property(i => i.Neighborhood).IsRequired();
            builder.Property(i => i.Neighborhood).HasMaxLength(100);
        }
    }
}