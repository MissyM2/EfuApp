using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedWeekCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks");

            migrationBuilder.DropIndex(
                name: "IX_Weeks_TermId",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "Weeks");

            migrationBuilder.AddColumn<int>(
                name: "WeekCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "WeekCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "WeekCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                column: "WeekCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                column: "WeekCount",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekCount",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TermId",
                table: "Weeks",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_TermId",
                table: "Weeks",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Terms_TermId",
                table: "Weeks",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "TermId");
        }
    }
}
