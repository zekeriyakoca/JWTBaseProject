using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseJWT.Infrastructure.EntityFramework.Configuration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}
