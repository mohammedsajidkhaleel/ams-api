using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeditemreceipt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item_receipts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    item_receipt_number = table.Column<string>(type: "text", nullable: false),
                    po_number = table.Column<string>(type: "text", nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_receipts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item_receipt_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    item_receipt_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_receipt_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_item_receipt_details_item_receipts_item_receipt_id",
                        column: x => x.item_receipt_id,
                        principalTable: "item_receipts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_item_receipt_details_item_receipt_id",
                table: "item_receipt_details",
                column: "item_receipt_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_receipts_item_receipt_number",
                table: "item_receipts",
                column: "item_receipt_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_receipt_details");

            migrationBuilder.DropTable(
                name: "item_receipts");
        }
    }
}
