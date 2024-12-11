using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement_System_API.Migrations
{
    /// <inheritdoc />
    public partial class Renamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentUTNumber",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "UTNumber",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Attendances",
                newName: "CheckedIn");

            migrationBuilder.AlterColumn<string>(
                name: "StudentUTNumber",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentUTNumber",
                table: "Attendances",
                column: "StudentUTNumber",
                principalTable: "Students",
                principalColumn: "UTNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentUTNumber",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "CheckedIn",
                table: "Attendances",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "StudentUTNumber",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UTNumber",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentUTNumber",
                table: "Attendances",
                column: "StudentUTNumber",
                principalTable: "Students",
                principalColumn: "UTNumber");
        }
    }
}
