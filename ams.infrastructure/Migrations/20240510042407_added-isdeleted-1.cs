using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedisdeleted1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "sponsors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "nationalities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "item_receipt_details",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "employee_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "employee_catogories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "departments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "sponsors");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "nationalities");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "items");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "item_receipt_details");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "employee_positions");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "employee_catogories");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "departments");
        }
    }
}
