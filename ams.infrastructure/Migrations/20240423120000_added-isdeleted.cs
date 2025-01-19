using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedisdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "item_receipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "assets",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "assets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "item_id",
                table: "assets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "po_number",
                table: "assets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_assets_item_id",
                table: "assets",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "fk_assets_item_item_id",
                table: "assets",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assets_item_item_id",
                table: "assets");

            migrationBuilder.DropIndex(
                name: "ix_assets_item_id",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "item_receipts");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "description",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "item_id",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "po_number",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "status",
                table: "assets");
        }
    }
}
