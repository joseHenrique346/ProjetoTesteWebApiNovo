using Infrastructure.Persistence.EFCore.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFCore.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(i => i.Id).HasName("id");
            builder.HasMany(i => i.ListCustomerAddress).WithOne(j => j.Customer).HasForeignKey(k => k.CustomerId);

            builder.Property(i => i.Name).HasColumnName("nome");
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Name).HasMaxLength(40);

            builder.Property(i => i.Code).HasColumnName("código");
            builder.Property(i => i.Code).IsRequired();
            builder.Property(i => i.Code).HasMaxLength(6);

            builder.Property(i => i.Document).HasColumnName("cpf");
            builder.Property(i => i.Document).IsRequired();
            builder.Property(i => i.Document).HasMaxLength(11);

            builder.Property(i => i.Phone).HasColumnName("telefone");
            builder.Property(i => i.Phone).IsRequired();
            builder.Property(i => i.Phone).HasMaxLength(11);

            builder.Property(i => i.BirthDate).HasColumnName("data_de_nascimento");
            builder.Property(i => i.BirthDate).IsRequired();
        }
    }
}