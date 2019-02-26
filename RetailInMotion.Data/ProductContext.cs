using Microsoft.EntityFrameworkCore;
using RetailInMotion.Domain;
using System;

namespace RetailInMotion.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
        }


        public virtual DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
