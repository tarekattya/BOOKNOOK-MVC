using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCP_BookStore.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DatePublished", "Description", "ISBN", "ImageUrl", "Language", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Astrid Lindgren", new DateTime(2013, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9789129688313", "/images/lejonhjärta.jpg", "Swedish", 139, "Bröderna Lejonhjärta" },
                    { 2, "J. R. R. Tolkien", new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780261102354", "/images/lotr.jpg", "English", 100, "The Fellowship of the Ring" },
                    { 3, "Dennis Lehane", new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780062068408", "/images/mystic-river.jpg", "English", 91, "Mystic River" },
                    { 4, "John Steinbeck", new DateTime(1994, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780062068408", "/images/of-mice-and-men.jpg", "English", 166, "Of Mice and Men" },
                    { 5, "Ernest Hemingway", new DateTime(1994, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780062068408", "/images/old-man-and-the-sea.jpg", "English", 84, "The Old Man and the Sea" },
                    { 6, "Cormac McCarthy", new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780307386458", "/images/the-road.jpg", "English", 95, "The Road" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
