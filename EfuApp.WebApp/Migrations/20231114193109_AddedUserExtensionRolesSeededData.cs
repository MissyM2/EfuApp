using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfuApp.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserExtensionRolesSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", null, "User", "USER" },
                    { "c7ac6cfe-1f10-4baf-b604-cde350db9554", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30a24107-d279-4e37-96fd-01af5b38cb27", 0, "f64bcd88-4fdb-424f-9612-314eaf32bc15", "user@efuapp.com", false, "Genericstudent", "User", false, null, "USER@EFUAPP.COM", "USER@EFUAPP.COM", "AQAAAAIAAYagAAAAENHBQC+71ZaJhsg/FZiLBtuBYDkB7eQkHE00axR8ODZtaW5ZcTOCDdayZVkqPKLroQ==", null, false, "d218858f-2d56-4d24-9551-135130b245da", false, "user@efuapp.com" },
                    { "40a24107-d279-4e37-96fd-01af5b38cb27", 0, "4d3b94a5-7da6-48c6-9736-09e450d44a68", "stud1@efuapp.com", false, "Student", "One", false, null, "STUD1@EFUAPP.COM", "STUD1@EFUAPP.COM", "AQAAAAIAAYagAAAAENPJcBnqqZ/VhHwFybyjJcMeFNv5KLbcMCEInGyPLG68KWhnzvWmkWnye9lep3xMhg==", null, false, "7ef42ea1-4d7c-42da-89d4-832c6a4d2f51", false, "stud1@efuapp.com" },
                    { "50a24107-d279-4e37-96fd-01af5b38cb27", 0, "01d2aac0-329e-4f31-a12a-8eb3daee61af", "stud2@efuapp.com", false, "Student", "Two", false, null, "STUD2@EFUAPP.COM", "STUD2@EFUAPP.COM", "AQAAAAIAAYagAAAAEG/Ehgpuay5hWd/nUXDZ18T5obqXIXHPGcDy97ayQ+fHixeuCxEHGCElAsJjL9HXtQ==", null, false, "df2f7bce-4929-4ed4-ad0e-33b2bc58548d", false, "stud2@efuapp.com" },
                    { "8e448afa-f008-446e-a52f-13c449803c2e", 0, "ff4f5753-1b04-4e9a-9cc8-341703439242", "admin@efuapp.com", false, "System", "Admin", false, null, "ADMIN@EFUAPP.COM", "ADMIN@EFUAPP.COM", "AQAAAAIAAYagAAAAELhXmXXMKfQ9DERTLOcpY8xNR8KjVo7GuMuPqjdtrtIJQqhVmOmFtoKcKco3fp2rvQ==", null, false, "6991d7c5-1595-4462-8315-776371e3c506", false, "admin@efuAPP.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" },
                    { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "40a24107-d279-4e37-96fd-01af5b38cb27" },
                    { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "50a24107-d279-4e37-96fd-01af5b38cb27" },
                    { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "40a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "50a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40a24107-d279-4e37-96fd-01af5b38cb27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50a24107-d279-4e37-96fd-01af5b38cb27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
