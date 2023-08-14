using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneToManyRelation_Book_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_Book");
        }
    }
}
