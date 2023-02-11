using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA.Data.Migrations
{
    /// <inheritdoc />
    public partial class migimgset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "UserDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "SubCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "SallerProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Saller",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProductCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Login",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "CommentReply",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "City",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "SallerProduct");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Saller");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "CommentReply");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "City");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Address");
        }
    }
}
