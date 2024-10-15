using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationAndFluentApi.Model;
using DataAnnotationAndFluentApi.SeedData;
using Microsoft.EntityFrameworkCore;

namespace DataAnnotationAndFluentApi.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
               ("Data Source=DESKTOP-6QTPFUC;Database=DataAnnotationDB;User ID=sa;Password=mssqlserverbey;TrustServerCertificate=true");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Annotation ile yaptıklarımı burada da Fluent api ile yapabilirim. İkisini aynı anda da kullanabilirim. Ama en son buradakiler override eder.
            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .HasColumnName("Book_Title")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.AuthorKey);

            //modelBuilder.Entity<Author>()
            //    .Property(x => x.AuthorName)
            //    .HasMaxLength(150)
            //    .IsRequired();

            //modelBuilder.Entity<Author>()
            //    .Ignore(x => x.AuthorName);

            modelBuilder.Entity<Book>()
                .ToTable("Books");

            // Bazı tablolara data eklememek için, istersem DB ayağa kalkarken tabloda, datada bulunsun istiyorsam
            // Seed Data
            modelBuilder.Entity<Author>()
            .HasData(
                new Author
                {
                    AuthorKey = 1,
                    FirstName = "William",
                    LastName = "Shakespeare",
                    Biography = "Sample bio text.",
                    BirthDate = new DateTime(1520, 06, 12),
                },
                 new Author
                 {
                     AuthorKey = 2,
                     FirstName = "Fyodor",
                     LastName = "Dostoyevski",
                     Biography = "Another sample bio text.",
                     BirthDate = new DateTime(1720, 11, 11),
                 }
            );

            modelBuilder.ApplyConfiguration(new BooksData());
            base.OnModelCreating(modelBuilder);
        }
    }
}
