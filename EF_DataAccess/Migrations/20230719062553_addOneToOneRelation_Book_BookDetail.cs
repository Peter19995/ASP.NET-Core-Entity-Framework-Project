﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addOneToOneRelation_Book_BookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "BookDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetail_Book_Id",
                table: "BookDetail",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetail_Books_Book_Id",
                table: "BookDetail",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetail_Books_Book_Id",
                table: "BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_BookDetail_Book_Id",
                table: "BookDetail");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "BookDetail");
        }
    }
}
