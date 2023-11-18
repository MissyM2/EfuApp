using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AttachedWeekAssessmentsToTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekAssessments_Courses_CourseId",
                table: "WeekAssessments");

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "WeekCount",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "WeekAssessments",
                newName: "TermId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekAssessments_CourseId",
                table: "WeekAssessments",
                newName: "IX_WeekAssessments_TermId");

            migrationBuilder.AddColumn<int>(
                name: "TermWeekCount",
                table: "Terms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekAssessments_Terms_TermId",
                table: "WeekAssessments",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekAssessments_Terms_TermId",
                table: "WeekAssessments");

            migrationBuilder.DropColumn(
                name: "TermWeekCount",
                table: "Terms");

            migrationBuilder.RenameColumn(
                name: "TermId",
                table: "WeekAssessments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekAssessments_TermId",
                table: "WeekAssessments",
                newName: "IX_WeekAssessments_CourseId");

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

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermId", "TermDesc", "TermName" },
                values: new object[,]
                {
                    { 1, "Winter, 2023", "Wi2023" },
                    { 2, "Spring, 2023", "Sp2023" },
                    { 3, "Summer, 2023", "Su2023" },
                    { 4, "Fall, 2023", "Fa2023" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WeekAssessments_Courses_CourseId",
                table: "WeekAssessments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
