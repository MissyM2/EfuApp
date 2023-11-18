using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class CleanedUpCourseWeekTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseWeeks_Courses_CourseId",
                table: "CourseWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWeeks_Weeks_WeekId",
                table: "CourseWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks");

            migrationBuilder.AlterColumn<int>(
                name: "TermId",
                table: "Weeks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WeekQuantity",
                table: "CourseWeeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 1,
                column: "TermId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 2,
                column: "TermId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 3,
                column: "TermId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 4,
                column: "TermId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWeeks_Courses_CourseId",
                table: "CourseWeeks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWeeks_Weeks_WeekId",
                table: "CourseWeeks",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "WeekId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "TermId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseWeeks_Courses_CourseId",
                table: "CourseWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWeeks_Weeks_WeekId",
                table: "CourseWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "WeekQuantity",
                table: "CourseWeeks");

            migrationBuilder.AlterColumn<int>(
                name: "TermId",
                table: "Weeks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 1,
                column: "TermId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 2,
                column: "TermId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 3,
                column: "TermId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 4,
                column: "TermId",
                value: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWeeks_Courses_CourseId",
                table: "CourseWeeks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWeeks_Weeks_WeekId",
                table: "CourseWeeks",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "WeekId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
