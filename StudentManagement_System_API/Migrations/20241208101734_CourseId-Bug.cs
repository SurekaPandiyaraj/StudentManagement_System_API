using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class CourseIdBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Courses_CourseId",
                table: "Timetables");

            migrationBuilder.DropIndex(
                name: "IX_Timetables_CourseId",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Timetables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Timetables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_CourseId",
                table: "Timetables",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Courses_CourseId",
                table: "Timetables",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
