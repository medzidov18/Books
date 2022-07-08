using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooks.Migrations
{
    /// <inheritdoc />
    public partial class _addImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                table: "AllBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "cccc3aec-54c6-4d4f-ab96-a24e44f5d191");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1e1a94e-1547-4be2-aee5-3b24548f1bd2", "AQAAAAEAACcQAAAAEBfeFhT1GqKg4oWQBNqALzwmlXvO5ILjladkSW4cZQ4kOQ2pxJvL/77L+2Cdnye7ag==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                table: "AllBooks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "bf3ac01f-aaf6-43ef-8e5e-dd532e0b32bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa436d85-f3ce-486f-8187-19021e9ddd60", "AQAAAAEAACcQAAAAEEPRGX09m+gHc6MF+tdj9NvSrnSWuZaOc44DoKh25rMcIzDNPNHR1v7dJatNkIs9pw==" });
        }
    }
}
