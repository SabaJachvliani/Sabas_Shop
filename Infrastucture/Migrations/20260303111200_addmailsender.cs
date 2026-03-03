using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class addmailsender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CodeActivationTime",
                table: "ShopCostumers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmd",
                table: "ShopCostumers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VarificationCode",
                table: "ShopCostumers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeActivationTime",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "IsConfirmd",
                table: "ShopCostumers");

            migrationBuilder.DropColumn(
                name: "VarificationCode",
                table: "ShopCostumers");
        }
    }
}
