using Infrastructure.Persistence.EFCore.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id).HasName("id");
            builder.HasOne(i => i.Brand).WithMany(j => j.ListProduct).HasForeignKey(k => k.BrandId).HasConstraintName("fkey_id_marca");
            builder.HasOne(i => i.Category).WithMany(j => j.ListProduct).HasForeignKey(k => k.CategoryId).HasConstraintName("fkey_id_categoria");

            builder.Property(i => i.Code).HasColumnName("código");
            builder.Property(i => i.Code).IsRequired();
            builder.Property(i => i.Code).HasMaxLength(6);

            builder.Property(i => i.Description).HasColumnName("descrição");
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(100);

            builder.Property(i => i.Price).HasColumnName("preço");
            builder.Property(i => i.Price).IsRequired();
        }
    }
}