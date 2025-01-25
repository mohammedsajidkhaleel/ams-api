using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderIndexmobileplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_index",
                table: "mobile_plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("166fbe6a-ad4a-4d13-99dc-f86155aa14c7"),
                column: "order_index",
                value: 2);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("3aa1a0a0-4178-47b1-8200-ab1a238c0274"),
                column: "order_index",
                value: 1);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("5677a4d2-d209-403e-b1f0-71a838c5ced3"),
                column: "order_index",
                value: 6);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("73450b9a-575d-4eb4-b2c4-3400d3f623b1"),
                column: "order_index",
                value: 3);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("cae99f89-1296-4b32-827e-6b836f2187fa"),
                column: "order_index",
                value: 5);

            migrationBuilder.UpdateData(
                table: "mobile_plans",
                keyColumn: "id",
                keyValue: new Guid("d298bb26-6c1f-46cb-a675-aa29d08e23bf"),
                column: "order_index",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_index",
                table: "mobile_plans");
        }
    }
}
