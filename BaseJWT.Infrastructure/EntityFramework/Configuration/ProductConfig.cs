using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseJWT.Infrastructure.EntityFramework.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
