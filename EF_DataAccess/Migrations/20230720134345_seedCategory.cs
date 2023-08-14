using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name)  VALUES('CAT 1')");
            migrationBuilder.Sql("INSERT INTO Categories (Name)  VALUES('CAT 2')");
            migrationBuilder.Sql("INSERT INTO Categories (Name)  VALUES('CAT 3')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
