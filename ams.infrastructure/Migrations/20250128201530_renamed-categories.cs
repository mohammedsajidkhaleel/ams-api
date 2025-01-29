using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ams.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamedcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_employee_catogories_employee_category_id",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employee_catogories",
                table: "employee_catogories");

            migrationBuilder.RenameTable(
                name: "employee_catogories",
                newName: "employee_categories");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employee_categories",
                table: "employee_categories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_employee_categories_employee_category_id",
                table: "employees",
                column: "employee_category_id",
                principalTable: "employee_categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_employee_categories_employee_category_id",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employee_categories",
                table: "employee_categories");

            migrationBuilder.RenameTable(
                name: "employee_categories",
                newName: "employee_catogories");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employee_catogories",
                table: "employee_catogories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_employee_catogories_employee_category_id",
                table: "employees",
                column: "employee_category_id",
                principalTable: "employee_catogories",
                principalColumn: "id");
        }
    }
}
