using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PostgreSQL.Configurations;
using PostgreSQL.Tables;

namespace PostgreSQL
{
    public class DbContextFOS : DbContext
    {
        public DbContextFOS(DbContextOptions<DbContextFOS> options) : base(options)
        {
            ;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderPositionEntity> OrderPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderPositionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
