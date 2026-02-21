using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class shopcustumerupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopCostumers_PersonalId",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "ShopCostumers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ShopCostumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "ShopCostumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "ShopCostumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ShopCostumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ShopCostumers");

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "ShopCostumers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCostumers_PersonalId",
                table: "ShopCostumers",
                column: "PersonalId",
                unique: true);
        }
    }
}
