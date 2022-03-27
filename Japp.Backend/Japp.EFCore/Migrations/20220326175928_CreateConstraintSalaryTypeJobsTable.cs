using Microsoft.EntityFrameworkCore.Migrations;

namespace Japp.EFCore.Migrations
{
    public partial class CreateConstraintSalaryTypeJobsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalaryType",
                table: "Jobs",
                type: "INTEGER",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalaryType",
                table: "Jobs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true,
                oldDefaultValue: 1);
        }
    }
}
