using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedmobileplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "assigned_plan",
                table: "sims",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mobile_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mobile_plans", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "mobile_plans",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("166fbe6a-ad4a-4d13-99dc-f86155aa14c7"), false, "80" },
                    { new Guid("3aa1a0a0-4178-47b1-8200-ab1a238c0274"), false, "50" },
                    { new Guid("5677a4d2-d209-403e-b1f0-71a838c5ced3"), false, "800" },
                    { new Guid("73450b9a-575d-4eb4-b2c4-3400d3f623b1"), false, "120" },
                    { new Guid("cae99f89-1296-4b32-827e-6b836f2187fa"), false, "450" },
                    { new Guid("d298bb26-6c1f-46cb-a675-aa29d08e23bf"), false, "230" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_mobile_plans_name",
                table: "mobile_plans",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mobile_plans");

            migrationBuilder.DropColumn(
                name: "assigned_plan",
                table: "sims");
        }
    }
}
