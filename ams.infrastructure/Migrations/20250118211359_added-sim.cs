using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedsim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_account = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    service_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sim_card_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    imei1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    last_update_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    assigned_to = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sims", x => x.id);
                    table.ForeignKey(
                        name: "fk_sims_employees_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_sims_assigned_to",
                table: "sims",
                column: "assigned_to");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sims");
        }
    }
}
