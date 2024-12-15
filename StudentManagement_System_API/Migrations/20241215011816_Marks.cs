using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class Marks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentUTNumber",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "UTNumber",
                table: "Marks");

            migrationBuilder.AlterColumn<string>(
                name: "StudentUTNumber",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "Admin",
                columns: new[] { "PasswordHash", "UserRole" },
                values: new object[] { "$2a$10$WBoWEVdNXx155SV0aaw.XOQnKsoZ0VoBnHEVDU8Kv3g7BlcgYdRRW", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentUTNumber",
                table: "Marks",
                column: "StudentUTNumber",
                principalTable: "Students",
                principalColumn: "UTNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentUTNumber",
                table: "Marks");

            migrationBuilder.AlterColumn<string>(
                name: "StudentUTNumber",
                table: "Marks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UTNumber",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "Admin",
                columns: new[] { "PasswordHash", "UserRole" },
                values: new object[] { "$2a$10$mGdf1y4guq1uRrah5t8ZSej8cZhoXu/vnJC/r8cDvBEidCo.J2PiO", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentUTNumber",
                table: "Marks",
                column: "StudentUTNumber",
                principalTable: "Students",
                principalColumn: "UTNumber");
        }
    }
}
