using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Users_UserRoleId",
                table: "Timetables");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Timetables_UserRoleId",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Timetables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Timetables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimetableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_UserRoleId",
                table: "Timetables",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TimetableId",
                table: "Subjects",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Users_UserRoleId",
                table: "Timetables",
                column: "UserRoleId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
