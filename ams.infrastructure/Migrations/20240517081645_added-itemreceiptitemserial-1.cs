using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeditemreceiptitemserial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_receipt_item_serial_number_item_receipt_detail_item_re",
                table: "item_receipt_item_serial_number");

            migrationBuilder.DropPrimaryKey(
                name: "pk_item_receipt_item_serial_number",
                table: "item_receipt_item_serial_number");

            migrationBuilder.RenameTable(
                name: "item_receipt_item_serial_number",
                newName: "item_receipt_item_serial_numbers");

            migrationBuilder.RenameIndex(
                name: "ix_item_receipt_item_serial_number_item_receipt_detail_id",
                table: "item_receipt_item_serial_numbers",
                newName: "ix_item_receipt_item_serial_numbers_item_receipt_detail_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_item_receipt_item_serial_numbers",
                table: "item_receipt_item_serial_numbers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_receipt_item_serial_numbers_item_receipt_details_item_",
                table: "item_receipt_item_serial_numbers",
                column: "item_receipt_detail_id",
                principalTable: "item_receipt_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_receipt_item_serial_numbers_item_receipt_details_item_",
                table: "item_receipt_item_serial_numbers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_item_receipt_item_serial_numbers",
                table: "item_receipt_item_serial_numbers");

            migrationBuilder.RenameTable(
                name: "item_receipt_item_serial_numbers",
                newName: "item_receipt_item_serial_number");

            migrationBuilder.RenameIndex(
                name: "ix_item_receipt_item_serial_numbers_item_receipt_detail_id",
                table: "item_receipt_item_serial_number",
                newName: "ix_item_receipt_item_serial_number_item_receipt_detail_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_item_receipt_item_serial_number",
                table: "item_receipt_item_serial_number",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_receipt_item_serial_number_item_receipt_detail_item_re",
                table: "item_receipt_item_serial_number",
                column: "item_receipt_detail_id",
                principalTable: "item_receipt_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
