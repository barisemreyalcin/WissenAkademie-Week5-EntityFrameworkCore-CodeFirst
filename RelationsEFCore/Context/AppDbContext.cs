using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RelationsEFCore.Models;

namespace RelationsEFCore.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
               ("Data Source=DESKTOP-6QTPFUC;Database=ProductDB;User ID=sa;Password=mssqlserverbey;TrustServerCertificate=true");
        }

        // Modellerimin db setleri
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        // key ilişkilerim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // kolonlarımın özelliklerini dbye yansıtırken sınırlandırabileceğim yer - fluent api

            // one to many
            modelBuilder.Entity<Product>() // Product -> yazaklarımı bu entity'e uygula
                .HasOne(prd => prd.Category) // category has one
                .WithMany(prd => prd.Products) // with many
                .HasForeignKey(prd => prd.CategoryRefID);

            // one to one
            modelBuilder.Entity<Product>()
                .HasOne(prd => prd.ProductDetail)
                .WithOne(prd => prd.Product)
                .HasForeignKey<ProductDetail>(prd => prd.ProductRefID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
