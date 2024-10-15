using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAnnotationAndFluentApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDataAnnotationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorTable",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTable", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Book_Title = table.Column<string>(type: "nvarchar(50)", maxLength: 150, nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BookPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishCount = table.Column<int>(type: "int", nullable: false),
                    AuthorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_AuthorTable_AuthorFK",
                        column: x => x.AuthorFK,
                        principalTable: "AuthorTable",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorTable",
                columns: new[] { "AuthorID", "Biography", "DoB", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Sample bio text.", new DateTime(1520, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Shakespeare" },
                    { 2, "Another sample bio text.", new DateTime(1720, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fyodor", "Dostoyevski" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "AuthorFK", "ISBN", "BookPrice", "PublishCount", "PublishDate", "Book_Title" },
                values: new object[,]
                {
                    { 1, 2, "1234-5678-9101-1121", 400m, 20, new DateTime(1874, 7, 14, 13, 23, 51, 287, DateTimeKind.Local).AddTicks(7170), "Suç ve Ceza" },
                    { 2, 2, "1234-5678-9101-1122", 300m, 15, new DateTime(1884, 7, 14, 13, 23, 51, 287, DateTimeKind.Local).AddTicks(7197), "Yer Altından Notlar" },
                    { 3, 2, "1234-5678-9101-1123", 200m, 10, new DateTime(1872, 7, 14, 13, 23, 51, 287, DateTimeKind.Local).AddTicks(7202), "Beyaz Geceler" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorFK",
                table: "Books",
                column: "AuthorFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AuthorTable");
        }
    }
}
