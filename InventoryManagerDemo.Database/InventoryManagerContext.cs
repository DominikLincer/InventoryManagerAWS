using InventoryManagerDemo.Database.Models;
using InventoryManagerDemo.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerDemo.Database
{
    public class InventoryManagerContext : DbContext
    {
        public virtual DbSet<Pallet> Pallets { get; set; }
        public virtual DbSet<Stillage> Stillages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var secretsManagerService = new SecretsManagerService();
            var dbUser = secretsManagerService.GetSecretAsync();
            optionsBuilder.UseSqlServer($"Server=id1mz8r4bv76r71.c2evrzxdwfu4.eu-central-1.rds.amazonaws.com; Database=InventoryManagerDemoDB; User Id='{dbUser.Username}'; Password='{dbUser.Password}';");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
