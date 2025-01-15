using Inside.StoreManagement.Domain.Entities;
using Inside.StoreManagement.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inside.StoreManagement.Persistence.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Price).IsRequired().HasPrecision(18, 2);

            base.Configure(entity);
        }
    }
}