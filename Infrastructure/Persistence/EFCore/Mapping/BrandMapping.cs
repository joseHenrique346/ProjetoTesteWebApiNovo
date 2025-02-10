using Infrastructure.Persistence.EFCore.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFCore.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("marca");

            builder.HasKey(i => i.Id).HasName("id");

            builder.Property(i => i.Code).HasColumnName("código");
            builder.Property(i => i.Code).IsRequired();
            builder.Property(i => i.Code).HasMaxLength(6);

            builder.Property(i => i.Description).HasColumnName("descrição");
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(100);
        }
    }
}