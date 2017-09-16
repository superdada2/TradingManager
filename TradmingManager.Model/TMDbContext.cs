using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingManager.Model
{
    public class TMDbContext: DbContext
    {
        public TMDbContext(DbContextOptions<TMDbContext> options)
            :base(options)
        { }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(t => t.UserId);
            modelBuilder.Entity<Transactions>()
                .Property(t => t.TransactionTime)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.HasDefaultSchema("TM");


        }
    }
}
