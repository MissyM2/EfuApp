using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDoneByToStudentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoneBy",
                table: "WeekAssessments",
                newName: "StudentUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentUser",
                table: "WeekAssessments",
                newName: "DoneBy");
        }
    }
}
