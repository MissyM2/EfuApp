using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDesc", "CourseName" },
                values: new object[,]
                {
                    { 1, "A course on English", "English 101" },
                    { 2, "A course on Math", "Math 101" },
                    { 3, "A course on Psychology", "Psych 101" },
                    { 4, "A course on Sociology", "Soc 101" }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "SuggestionId", "SuggestionDesc", "SuggestionName" },
                values: new object[,]
                {
                    { 1, "Read a book.", "Suggestion1" },
                    { 2, "Make a list.", "Suggestion2" },
                    { 3, "Take notes.", "Suggestion3" },
                    { 4, "Start early.", "Suggestion4" }
                });

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

            migrationBuilder.InsertData(
                table: "Deliverables",
                columns: new[] { "DeliverableId", "AssignmentDate", "CourseId", "DeliverableDesc", "DeliverableName", "DueDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "5 paragraphs", "English Essay", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "5 paragraphs", "Sociology Term Paper", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "5 pages; topic of your choice", "Psychology Study", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "2 worksheets", "Math Homework", new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Weeks",
                columns: new[] { "WeekId", "LeastDifficult", "LikedLeast", "LikedMost", "MostDifficult", "TermId", "WeekDesc", "WeekName" },
                values: new object[,]
                {
                    { 1, "", "", "", "", 2, "first week of semester", "1" },
                    { 2, "", "", "", "", 2, "second week of semester", "2" },
                    { 3, "", "", "", "", 4, "third week of semester", "3" },
                    { 4, "", "", "", "", 4, "fourth week of semester", "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "DeliverableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "DeliverableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "DeliverableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "DeliverableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "SuggestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "SuggestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "SuggestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "SuggestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weeks",
                keyColumn: "WeekId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Terms",
                keyColumn: "TermId",
                keyValue: 4);
        }
    }
}
