using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedWeeksAddedWeekAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeastDifficult",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "LikedLeast",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "LikedMost",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "MostDifficult",
                table: "Weeks");

            migrationBuilder.DropColumn(
                name: "WeekDesc",
                table: "Weeks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeastDifficult",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LikedLeast",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LikedMost",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MostDifficult",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeekDesc",
                table: "Weeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 1,
                columns: new[] { "LeastDifficult", "LikedLeast", "LikedMost", "MostDifficult", "WeekDesc" },
                values: new object[] { "", "", "", "", "first week of semester" });

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 2,
                columns: new[] { "LeastDifficult", "LikedLeast", "LikedMost", "MostDifficult", "WeekDesc" },
                values: new object[] { "", "", "", "", "second week of semester" });

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 3,
                columns: new[] { "LeastDifficult", "LikedLeast", "LikedMost", "MostDifficult", "WeekDesc" },
                values: new object[] { "", "", "", "", "third week of semester" });

            migrationBuilder.UpdateData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 4,
                columns: new[] { "LeastDifficult", "LikedLeast", "LikedMost", "MostDifficult", "WeekDesc" },
                values: new object[] { "", "", "", "", "fourth week of semester" });
        }
    }
}
