using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedprojectlicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "po_number",
                table: "licenses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "project_id",
                table: "licenses",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "po_number",
                table: "licenses");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "licenses");
        }
    }
}
