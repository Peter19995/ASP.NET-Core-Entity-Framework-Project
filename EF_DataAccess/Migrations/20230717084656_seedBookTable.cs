using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123B12", 10.99m, "Spider without Duty" },
                    { 2, "12S3B12", 11.99m, "Fortune Of Time" },
                    { 3, "123L", 20.99m, "Fake Sunday" },
                    { 4, "123M", 25.99m, "Cookie Jar" },
                    { 5, "123Q", 11.99m, "Cloudy Forest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);
        }
    }
}
