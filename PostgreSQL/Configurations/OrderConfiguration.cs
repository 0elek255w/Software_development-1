using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Tables;

namespace PostgreSQL.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(order => order.ID);

            builder
                .HasIndex(order => order.UserID)
                .IsUnique(false);
        }
    }
}
