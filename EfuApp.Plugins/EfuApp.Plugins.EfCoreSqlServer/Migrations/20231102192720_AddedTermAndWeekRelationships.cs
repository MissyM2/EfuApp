using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedTermAndWeekRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TermId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "TermId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "TermId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                column: "TermId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                column: "TermId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TermId",
                table: "Courses",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Terms_TermId",
                table: "Courses",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "TermId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Terms_TermId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TermId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "Courses");
        }
    }
}
