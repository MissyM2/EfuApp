using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RevisionsToSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseWeeks");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.CreateTable(
                name: "WeekAssessments",
                columns: table => new
                {
                    WeekAssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    LikedLeast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikedMost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MostDifficult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeastDifficult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekAssessments", x => x.WeekAssessmentId);
                    table.ForeignKey(
                        name: "FK_WeekAssessments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekAssessments_CourseId",
                table: "WeekAssessments",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekAssessments");

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    WeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.WeekId);
                });

            migrationBuilder.CreateTable(
                name: "CourseWeeks",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    WeekId = table.Column<int>(type: "int", nullable: false),
                    WeekQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseWeeks", x => new { x.CourseId, x.WeekId });
                    table.ForeignKey(
                        name: "FK_CourseWeeks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseWeeks_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "WeekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Weeks",
                columns: new[] { "WeekId", "WeekName" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseWeeks_WeekId",
                table: "CourseWeeks",
                column: "WeekId");
        }
    }
}
