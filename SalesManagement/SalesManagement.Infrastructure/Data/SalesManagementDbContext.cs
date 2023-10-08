using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SalesManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Data
{
    public class SalesManagementDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .ToTable("Product");
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=MIRAZIZ\\SQLEXPRESS;Initial Catalog=SalesManagement;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
