using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdentityColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WeekAssessments",
                newName: "WeekAssessmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Terms",
                newName: "TermId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suggestions",
                newName: "SuggestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Deliverables",
                newName: "DeliverableId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekAssessmentId",
                table: "WeekAssessments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TermId",
                table: "Terms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SuggestionId",
                table: "Suggestions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DeliverableId",
                table: "Deliverables",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }
    }
}
