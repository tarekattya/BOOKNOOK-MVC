using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCP_BookStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DatePublished", "Description", "ISBN", "ImageUrl", "Language", "Price", "Title" },
                values: new object[,]
                {
                    { 7, "Cormac McCarthy", new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780307386458", "/images/Battelfield.jpg", "English", 180, "Battlefield of the mind" },
                    { 8, "Cormac McCarthy", new DateTime(2008, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780307386458", "/images/Dont believe.jpg", "English", 95, "Dont Believe Everything You Think" },
                    { 9, "Cormac McCarthy", new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "9780307381122", "/images/flyIt like.jpg", "English", 225, "Fly It Like you Stole It" },
                    { 10, "Cormac McCarthy", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/HarryPotter.jpg", "English", 225, "Harry Potter:JK Rowling " },
                    { 11, "Agatha McCarthy", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/how to talk.jpg", "English", 225, "How to Talk to AnyOne " },
                    { 12, "Cormac McCarthy", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899397381122", "/images/inner exellience.jpg", "English", 225, "Inner Excellence " },
                    { 13, "Ernest Hemingway", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/IronFlame.webp", "English", 400, "Iron Flame  " },
                    { 14, "Cormac McCarthy", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/RichDad.webp", "English", 225, "Rich Dad Poor Dad " },
                    { 15, "Cormac McCarthy", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/Source code.jpg", "English", 225, "Source Code" },
                    { 16, "Cormac McCarthy", new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/theWay.jpg", "English", 225, "The Way Of Superior Man" },
                    { 17, "Cormac McCarthy", new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/tradinig in thezone.jpg", "English", 300, "Trading In The Zone" },
                    { 18, "Cormac McCarthy", new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "loreim ipsum", "8899307381122", "/images/You Become What You Think about.jpg", "English", 300, "You Become What You Think about" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
