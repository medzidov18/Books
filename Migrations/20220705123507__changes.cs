using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooks.Migrations
{
    /// <inheritdoc />
    public partial class _changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9d841351-fbcc-469f-a6ef-a210bbc04614");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b666ddc7-0600-44e7-b0be-c9c6a53e7489", "AQAAAAEAACcQAAAAENAtFeNN3XaetstdbyVeTVY2fSv8JWe//ob2M+CBVS/69UezL0Y5BgQJkTdsOs6sZA==" });
        }
    }
}
