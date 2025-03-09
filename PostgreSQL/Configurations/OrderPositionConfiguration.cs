using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Tables;

namespace PostgreSQL.Configurations
{
    public class OrderPositionConfiguration : IEntityTypeConfiguration<OrderPositionEntity>
    {
        public void Configure(EntityTypeBuilder<OrderPositionEntity> builder)
        {
            builder.HasKey(orderPosition => orderPosition.ID);

            builder
                .HasIndex(orderPosition => orderPosition.OrderID)
                .IsUnique(false);

            builder
                .HasIndex(orderPosition => orderPosition.DishID)
                .IsUnique(false);
        }
    }
}
