using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA.Data.Migrations
{
    /// <inheritdoc />
    public partial class migjwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Login_LoginId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LoginId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Login",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Login",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserId",
                table: "Login",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_User_UserId",
                table: "Login",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_User_UserId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_UserId",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Login");

            migrationBuilder.AddColumn<Guid>(
                name: "LoginId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_LoginId",
                table: "User",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Login_LoginId",
                table: "User",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
