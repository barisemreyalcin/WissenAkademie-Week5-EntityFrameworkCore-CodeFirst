using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManyToManyEFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyEFCore.Context
{
    public class AppDBContext : DbContext // bütün işi bu yapıyor
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
               ("Data Source=DESKTOP-6QTPFUC;Database=SchoolManyToManyDB;User ID=sa;Password=mssqlserverbey;TrustServerCertificate=true");
        }

        // Modellerimin db setleri
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        // Fluent api gerek yok kendisi anlar bu kez (ICollection'dan anlar)
        // İstersem yazarım tabi
    }
}
