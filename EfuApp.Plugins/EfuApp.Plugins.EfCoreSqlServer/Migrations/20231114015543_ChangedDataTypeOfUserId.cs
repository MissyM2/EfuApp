using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDataTypeOfUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentUser",
                table: "WeekAssessments",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WeekAssessments",
                newName: "StudentUser");
        }
    }
}
