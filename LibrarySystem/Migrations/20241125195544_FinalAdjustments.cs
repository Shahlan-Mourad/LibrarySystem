using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class FinalAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birth_Date",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Publication_Date",
                table: "Books",
                newName: "Publication_Year");

            migrationBuilder.AddColumn<int>(
                name: "Birth",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birth",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Publication_Year",
                table: "Books",
                newName: "Publication_Date");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birth_Date",
                table: "Authors",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
