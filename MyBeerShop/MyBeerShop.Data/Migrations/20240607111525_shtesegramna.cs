using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBeerShop.Data.Migrations
{
    public partial class shtesegramna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItem_Beers_BeerId",
                table: "cartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItem_Carts_CartId",
                table: "cartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartItem",
                table: "cartItem");

            migrationBuilder.RenameTable(
                name: "cartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_cartItem_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_cartItem_BeerId",
                table: "CartItems",
                newName: "IX_CartItems_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Beers_BeerId",
                table: "CartItems",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Beers_BeerId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "cartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "cartItem",
                newName: "IX_cartItem_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_BeerId",
                table: "cartItem",
                newName: "IX_cartItem_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartItem",
                table: "cartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItem_Beers_BeerId",
                table: "cartItem",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItem_Carts_CartId",
                table: "cartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
