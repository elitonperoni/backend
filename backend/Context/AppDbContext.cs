using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>()
             .HasIndex(c => new { c.Nome, c.Cpf })
             .IsUnique();
        }

    }
}
