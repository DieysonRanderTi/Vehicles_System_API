using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SaleAds_CarModelId",
                table: "SaleAds",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAds_MakeCarId",
                table: "SaleAds",
                column: "MakeCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAds_CarModels_CarModelId",
                table: "SaleAds",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAds_MakeCars_MakeCarId",
                table: "SaleAds",
                column: "MakeCarId",
                principalTable: "MakeCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleAds_CarModels_CarModelId",
                table: "SaleAds");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAds_MakeCars_MakeCarId",
                table: "SaleAds");

            migrationBuilder.DropIndex(
                name: "IX_SaleAds_CarModelId",
                table: "SaleAds");

            migrationBuilder.DropIndex(
                name: "IX_SaleAds_MakeCarId",
                table: "SaleAds");
        }
    }
}
