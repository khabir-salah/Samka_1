

using System.Reflection;
//using System.Transactions;
using Domain.Aggregates.ChatAggregate.Entities;
using Domain.Aggregates.MarketPlaceAggregate.Entities;
using Domain.Aggregates.PaymentAggregate.Entities;
using Domain.Aggregates.ServiceAggregate.Entities;
using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Aggregates.UserAggregate.Constants;
using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context
{
    public class SamkaDBContext(DbContextOptions<SamkaDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Service> services => Set<Service>();
        public DbSet<Chat> chats => Set<Chat>();
        public DbSet<Transaction> transactions => Set<Transaction>();
        public DbSet<ServiceCategory> ServiceCategories => Set<ServiceCategory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Role>().HasData
                (
                    new Role(RoleConst.Admin),
                    new Role(RoleConst.Manager),
                    new Role(RoleConst.Client)
                );
          
        }
    }
}
