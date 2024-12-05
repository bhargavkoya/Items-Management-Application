using Microsoft.EntityFrameworkCore;
using MyApp_aspnetcorenine.Models;

namespace MyApp_aspnetcorenine.Data
{
    public class MyAppDataContext : DbContext
    {
        public MyAppDataContext(DbContextOptions<MyAppDataContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic=> new {
                ic.ItemId,
                ic.ClientId
            });

            modelBuilder.Entity<ItemClient>().HasOne(i=> i.Item).WithMany(c=>c.ItemClients).HasForeignKey(i=>i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(i => i.ItemClients).HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = 4, Name = "MicroPhone", Price = 50, SerialNumberId = 2 });
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber() { Id = 2, Name = "MICRO23", ItemId = 4 });
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id=1,Name="Electronics"},
                new Category() { Id=2,Name="Books"}
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemsClients { get; set; }
    }
}
