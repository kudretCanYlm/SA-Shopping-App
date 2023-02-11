using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA.Data.Migrations
{
    /// <inheritdoc />
    public partial class msdf454 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SallerProduct_GuidProductId",
                table: "SallerProduct",
                column: "GuidProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SallerProduct_Product_GuidProductId",
                table: "SallerProduct",
                column: "GuidProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SallerProduct_Product_GuidProductId",
                table: "SallerProduct");

            migrationBuilder.DropIndex(
                name: "IX_SallerProduct_GuidProductId",
                table: "SallerProduct");
        }
    }
}
