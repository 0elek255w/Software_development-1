using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQL.Tables;

namespace PostgreSQL.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.ID);

            builder
                .HasIndex(user => user.Email)
                .IsUnique();

            builder
                .HasMany(user => user.Orders)
                .WithOne(order => order.User)
                .HasForeignKey(order => order.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
