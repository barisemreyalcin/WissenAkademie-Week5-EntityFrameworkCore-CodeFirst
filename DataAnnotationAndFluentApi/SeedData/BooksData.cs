using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationAndFluentApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAnnotationAndFluentApi.SeedData
{
    public class BooksData : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                    new Book
                    {
                        BookKey = 1,
                        Title = "Suç ve Ceza",
                        AuthorFK = 2,
                        ISBN = "1234-5678-9101-1121",
                        Price = 400,
                        PublishDate = DateTime.Now.AddYears(-150),
                        PublishCount = 20
                    },
                    new Book
                    {
                        BookKey = 2,
                        Title = "Yer Altından Notlar",
                        AuthorFK = 2,
                        ISBN = "1234-5678-9101-1122",
                        Price = 300,
                        PublishDate = DateTime.Now.AddYears(-140),
                        PublishCount = 15
                    },
                     new Book
                     {
                         BookKey = 3,
                         Title = "Beyaz Geceler",
                         AuthorFK = 2,
                         ISBN = "1234-5678-9101-1123",
                         Price = 200,
                         PublishDate = DateTime.Now.AddYears(-152),
                         PublishCount = 10
                     }
                );
        }
    }
}
