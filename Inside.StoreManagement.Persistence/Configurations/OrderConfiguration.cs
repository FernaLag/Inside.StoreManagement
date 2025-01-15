using Inside.StoreManagement.Domain.Entities;
using Inside.StoreManagement.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inside.StoreManagement.Persistence.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            entity.HasMany(o => o.OrderProducts)
                  .WithOne()
                  .HasForeignKey(p => p.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            base.Configure(entity);
        }
    }
}
