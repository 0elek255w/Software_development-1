using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Tables;

namespace PostgreSQL.Configurations
{
    class DishConfiguration : IEntityTypeConfiguration<DishEntity>
    {
        public void Configure(EntityTypeBuilder<DishEntity> builder)
        {
            builder.HasKey(dish => dish.ID);

            builder
                .HasMany(dish => dish.Orders)
                .WithOne(order => order.Dish)
                .HasForeignKey(order => order.DishID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
