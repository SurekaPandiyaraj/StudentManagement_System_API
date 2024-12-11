using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class Batchupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Students");
        }
    }
}
