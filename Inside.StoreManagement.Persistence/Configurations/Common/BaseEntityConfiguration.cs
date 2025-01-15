using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Inside.StoreManagement.Domain.Entities.Common;

namespace Inside.StoreManagement.Persistence.Configurations.Common
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CreatedAt)
                .HasColumnType("datetime2");

            builder.Property(o => o.UpdatedAt)
                .HasColumnType("datetime2");
        }
    }
}