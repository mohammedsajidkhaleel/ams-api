using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeditemreceiptitemserial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_receipt_details_item_receipts_item_receipt_id",
                table: "item_receipt_details");

            migrationBuilder.AlterColumn<Guid>(
                name: "item_receipt_id",
                table: "item_receipt_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "item_receipt_item_serial_number",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<string>(type: "text", nullable: false),
                    item_receipt_detail_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_receipt_item_serial_number", x => x.id);
                    table.ForeignKey(
                        name: "fk_item_receipt_item_serial_number_item_receipt_detail_item_re",
                        column: x => x.item_receipt_detail_id,
                        principalTable: "item_receipt_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_item_receipt_item_serial_number_item_receipt_detail_id",
                table: "item_receipt_item_serial_number",
                column: "item_receipt_detail_id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_receipt_details_item_receipts_item_receipt_id",
                table: "item_receipt_details",
                column: "item_receipt_id",
                principalTable: "item_receipts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_receipt_details_item_receipts_item_receipt_id",
                table: "item_receipt_details");

            migrationBuilder.DropTable(
                name: "item_receipt_item_serial_number");

            migrationBuilder.AlterColumn<Guid>(
                name: "item_receipt_id",
                table: "item_receipt_details",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_item_receipt_details_item_receipts_item_receipt_id",
                table: "item_receipt_details",
                column: "item_receipt_id",
                principalTable: "item_receipts",
                principalColumn: "id");
        }
    }
}
