using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeKeeper.Migrations
{
    /// <inheritdoc />
    public partial class updatedphoneNumbertobestring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a459a57-cf5c-43ae-b415-f776ad3332e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "558e9433-9719-40ec-abd5-a0f195a28edc");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Reservation",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Schedule", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2089d65a-a5f1-4599-bb55-b88acfdf180f", 0, "6b5cec08-e7a2-4fe3-abcd-333574c25db0", "Employee", null, false, false, null, null, "ZEUS", null, null, false, new[] { 1, 2, 3 }, "ec3b242f-4597-49f1-a7ac-6741639f4438", false, "zeus" },
                    { "f633929f-eaca-4bf6-8e13-9835135a0517", 0, "f83e4909-d5cc-4052-95ad-d918645cb30d", "Employee", null, false, false, null, null, "RIOT", null, null, false, new[] { 5, 6, 0 }, "bd2173aa-d429-40b3-9614-05d6df6241df", false, "riot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2089d65a-a5f1-4599-bb55-b88acfdf180f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f633929f-eaca-4bf6-8e13-9835135a0517");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Reservation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Schedule", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4a459a57-cf5c-43ae-b415-f776ad3332e3", 0, "a1561c9f-7ec8-49f1-911d-393e88a71362", "Employee", null, false, false, null, null, "ZEUS", null, null, false, new[] { 1, 2, 3 }, "c810adfe-a8f0-490a-970f-d16996bc1bf3", false, "zeus" },
                    { "558e9433-9719-40ec-abd5-a0f195a28edc", 0, "d52523c0-e8a4-4b74-a1fe-32f75ae402e4", "Employee", null, false, false, null, null, "RIOT", null, null, false, new[] { 5, 6, 0 }, "31041d31-6736-41a1-b1c0-aca54ec38ba3", false, "riot" }
                });
        }
    }
}
