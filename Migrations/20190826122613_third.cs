using Microsoft.EntityFrameworkCore.Migrations;

namespace ReSaleCarBuyerAPI.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerDetails_Manufacturer_ManufacturerId",
                table: "BuyerDetails");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "BuyerDetails",
                newName: "CarModelId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerDetails_ManufacturerId",
                table: "BuyerDetails",
                newName: "IX_BuyerDetails_CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerDetails_CarDetails_CarModelId",
                table: "BuyerDetails",
                column: "CarModelId",
                principalTable: "CarDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerDetails_CarDetails_CarModelId",
                table: "BuyerDetails");

            migrationBuilder.RenameColumn(
                name: "CarModelId",
                table: "BuyerDetails",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerDetails_CarModelId",
                table: "BuyerDetails",
                newName: "IX_BuyerDetails_ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerDetails_Manufacturer_ManufacturerId",
                table: "BuyerDetails",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
