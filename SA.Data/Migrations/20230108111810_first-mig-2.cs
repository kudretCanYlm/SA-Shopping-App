using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_User_UserId",
                table: "UserDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_User_UserId",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDetail");
        }
    }
}
