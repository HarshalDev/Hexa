using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReSaleCarBuyerAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "BuyerDetails");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "BuyerDetails",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerDetails",
                table: "BuyerDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    SellingPrice = table.Column<double>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDetails_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetails_ManufacturerId",
                table: "BuyerDetails",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_ManufacturerId",
                table: "CarDetails",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerDetails_Manufacturer_ManufacturerId",
                table: "BuyerDetails",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerDetails_Manufacturer_ManufacturerId",
                table: "BuyerDetails");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerDetails",
                table: "BuyerDetails");

            migrationBuilder.DropIndex(
                name: "IX_BuyerDetails_ManufacturerId",
                table: "BuyerDetails");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "BuyerDetails");

            migrationBuilder.RenameTable(
                name: "BuyerDetails",
                newName: "Buyers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");
        }
    }
}
