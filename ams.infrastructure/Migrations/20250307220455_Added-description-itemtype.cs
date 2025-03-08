using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addeddescriptionitemtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "purchase_orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "item_type",
                table: "items",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "item_type",
                table: "items");
        }
    }
}
