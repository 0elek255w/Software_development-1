using Microsoft.EntityFrameworkCore;
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

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<DishEntity> DishEntity { get; set; }
        public DbSet<OrderEntity> OrderEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
