using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class ExamEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Batch",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 2024);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Exams");
        }
    }
}
