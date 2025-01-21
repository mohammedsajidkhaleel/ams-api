using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedaccessories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accessories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "accessories",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("071f7121-0f58-4c31-8152-1bd37a1be208"), false, "Laptop Sleeve" },
                    { new Guid("129f3a50-9939-44d2-a12d-b6dd8c434e89"), false, "Laptop Bag" },
                    { new Guid("19105bc4-0783-48c5-8736-e1e3b85b3781"), false, "Laptop Stand" },
                    { new Guid("3b2af4e0-6ea6-474e-9d5a-aa488f855a64"), false, "Wireless KB/M" },
                    { new Guid("40dd02ed-29eb-423c-b7d7-dd96d035692e"), false, "Surge Protector/Power Strip " },
                    { new Guid("624b4b3a-0e18-4969-b939-a1fca8b26d51"), false, "Keyboard" },
                    { new Guid("701a9764-9392-42e6-9bae-a0b71904c0d9"), false, "Headset" },
                    { new Guid("74941def-6a9b-4067-9f0a-891d47d9b098"), false, "Wireless Keyboard and Mouse" },
                    { new Guid("a5b2a115-71e0-41c9-91d6-8b6c06ab351b"), false, "Backpack" },
                    { new Guid("c544dd6a-75f8-4148-9ff7-9d480684ca67"), false, "Mouse" },
                    { new Guid("df1d9565-21f9-44bc-9a75-9635d4c82c4e"), false, "Cable Management Accessories" },
                    { new Guid("e3414d50-27e8-43dd-b0d6-9d655c2603c3"), false, "Cleaning Kits" },
                    { new Guid("e50d5693-a711-4184-97f9-436bc76f0420"), false, "USB Hub" },
                    { new Guid("e9f09312-4a09-4e26-abfb-7c9453cb4d28"), false, "External Hard Drive/SSD " },
                    { new Guid("f23bcb62-63bd-4ae9-ac8f-432871f8ae54"), false, "Screen Protector" },
                    { new Guid("f266170a-b637-4119-b417-9b9c754a3c45"), false, "Webcam" },
                    { new Guid("f3a32464-31f6-4aba-a06f-34da057383ff"), false, "USB Dongle" },
                    { new Guid("f87a1e53-63f3-4586-a809-06731431bc07"), false, "Docking Station" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accessories");
        }
    }
}
