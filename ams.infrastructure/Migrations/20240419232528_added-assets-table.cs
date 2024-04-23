using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedassetstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    parent_department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                    table.ForeignKey(
                        name: "fk_departments_departments_parent_department_id",
                        column: x => x.parent_department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employee_catogories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee_catogories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee_positions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", maxLength: 250, nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nationalities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nationalities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sponsors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sponsors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    sponsor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    employee_category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    nationality_id = table.Column<Guid>(type: "uuid", nullable: true),
                    employee_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    mobile = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    doj = table.Column<DateOnly>(type: "date", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: true),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employees_employee_catogories_employee_category_id",
                        column: x => x.employee_category_id,
                        principalTable: "employee_catogories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employees_employee_position_employee_position_id",
                        column: x => x.employee_position_id,
                        principalTable: "employee_positions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employees_nationality_nationality_id",
                        column: x => x.nationality_id,
                        principalTable: "nationalities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employees_project_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employees_sponsor_sponsor_id",
                        column: x => x.sponsor_id,
                        principalTable: "sponsors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    serial_number = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    assigned_to = table.Column<Guid>(type: "uuid", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: true),
                    creation_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assets", x => x.id);
                    table.ForeignKey(
                        name: "fk_assets_employee_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_assets_project_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_items_item_category_id",
                table: "items",
                column: "item_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_receipt_details_item_id",
                table: "item_receipt_details",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_categories_parent_item_category_id",
                table: "item_categories",
                column: "parent_item_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_assets_assigned_to",
                table: "assets",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "ix_assets_project_id",
                table: "assets",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_parent_department_id",
                table: "departments",
                column: "parent_department_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_department_id",
                table: "employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_employee_category_id",
                table: "employees",
                column: "employee_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_employee_position_id",
                table: "employees",
                column: "employee_position_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_nationality_id",
                table: "employees",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_project_id",
                table: "employees",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_sponsor_id",
                table: "employees",
                column: "sponsor_id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_categories_item_categories_parent_item_category_id",
                table: "item_categories",
                column: "parent_item_category_id",
                principalTable: "item_categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_item_receipt_details_items_item_id",
                table: "item_receipt_details",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_items_item_categories_item_category_id",
                table: "items",
                column: "item_category_id",
                principalTable: "item_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_item_categories_item_categories_parent_item_category_id",
                table: "item_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_item_receipt_details_items_item_id",
                table: "item_receipt_details");

            migrationBuilder.DropForeignKey(
                name: "fk_items_item_categories_item_category_id",
                table: "items");

            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employee_catogories");

            migrationBuilder.DropTable(
                name: "employee_positions");

            migrationBuilder.DropTable(
                name: "nationalities");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "sponsors");

            migrationBuilder.DropIndex(
                name: "ix_items_item_category_id",
                table: "items");

            migrationBuilder.DropIndex(
                name: "ix_item_receipt_details_item_id",
                table: "item_receipt_details");

            migrationBuilder.DropIndex(
                name: "ix_item_categories_parent_item_category_id",
                table: "item_categories");
        }
    }
}
