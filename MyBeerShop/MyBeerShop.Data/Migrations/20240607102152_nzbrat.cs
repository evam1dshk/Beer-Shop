using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class nzbrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Beers_BeerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "BeerId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "cartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartItem_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_BeerId",
                table: "cartItem",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItem_CartId",
                table: "cartItem",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Beers_BeerId",
                table: "Carts",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Beers_BeerId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "cartItem");

            migrationBuilder.AlterColumn<int>(
                name: "BeerId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Beers_BeerId",
                table: "Carts",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
