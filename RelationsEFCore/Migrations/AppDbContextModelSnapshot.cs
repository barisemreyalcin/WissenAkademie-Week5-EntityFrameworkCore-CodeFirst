﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationsEFCore.Context;

#nullable disable

namespace RelationsEFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RelationsEFCore.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RelationsEFCore.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryRefID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockAmount")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryRefID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RelationsEFCore.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductRefID")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ProductDetailID");

                    b.HasIndex("ProductRefID")
                        .IsUnique();

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("RelationsEFCore.Models.Product", b =>
                {
                    b.HasOne("RelationsEFCore.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RelationsEFCore.Models.ProductDetail", b =>
                {
                    b.HasOne("RelationsEFCore.Models.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("RelationsEFCore.Models.ProductDetail", "ProductRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RelationsEFCore.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RelationsEFCore.Models.Product", b =>
                {
                    b.Navigation("ProductDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
