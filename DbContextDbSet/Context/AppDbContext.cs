using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContextDbSet.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextDbSet.Context
{
    public class AppDbContext : DbContext
    {
        // hangi db'ye bağlanacağımı söylüyorum (constructor ile veya aşağıdaki gibi)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=DESKTOP-6QTPFUC;Database=AuthorDB;User ID=sa;Password=mssqlserverbey;TrustServerCertificate=true");

            // Windows auth
            //optionsBuilder.UseSqlServer
                //("Data Source=DESKTOP-6QTPFUC;Database=AuthorDB;Integrated Security;TrustServerCertificate=true");
        }

        // DB setler. Modellerini oluşturduğum yapıları collection olarak ekliyorum
        // Tablolardaki datalara karşılık gelen satır ve sütunların bilgilerini içeren collectionların...
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
 