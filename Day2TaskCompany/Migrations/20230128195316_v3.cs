using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2TaskCompany.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksOnProjects_Employees_EmployeesSSN",
                table: "WorksOnProjects");

            migrationBuilder.DropIndex(
                name: "IX_WorksOnProjects_EmployeesSSN",
                table: "WorksOnProjects");

            migrationBuilder.DropColumn(
                name: "EmployeesSSN",
                table: "WorksOnProjects");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksOnProjects_Employees_EmpSSN",
                table: "WorksOnProjects",
                column: "EmpSSN",
                principalTable: "Employees",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksOnProjects_Employees_EmpSSN",
                table: "WorksOnProjects");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesSSN",
                table: "WorksOnProjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorksOnProjects_EmployeesSSN",
                table: "WorksOnProjects",
                column: "EmployeesSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksOnProjects_Employees_EmployeesSSN",
                table: "WorksOnProjects",
                column: "EmployeesSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }
    }
}
