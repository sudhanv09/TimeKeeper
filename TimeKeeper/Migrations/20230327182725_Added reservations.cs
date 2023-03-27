using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeKeeper.Migrations
{
    /// <inheritdoc />
    public partial class Addedreservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82ecc253-584d-400a-94a4-bc417bbaa90a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "925f70c3-688c-456d-9487-8c57413cbad2");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    ReturnCustomer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Schedule", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4a459a57-cf5c-43ae-b415-f776ad3332e3", 0, "a1561c9f-7ec8-49f1-911d-393e88a71362", "Employee", null, false, false, null, null, "ZEUS", null, null, false, new[] { 1, 2, 3 }, "c810adfe-a8f0-490a-970f-d16996bc1bf3", false, "zeus" },
                    { "558e9433-9719-40ec-abd5-a0f195a28edc", 0, "d52523c0-e8a4-4b74-a1fe-32f75ae402e4", "Employee", null, false, false, null, null, "RIOT", null, null, false, new[] { 5, 6, 0 }, "31041d31-6736-41a1-b1c0-aca54ec38ba3", false, "riot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a459a57-cf5c-43ae-b415-f776ad3332e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "558e9433-9719-40ec-abd5-a0f195a28edc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Schedule", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "82ecc253-584d-400a-94a4-bc417bbaa90a", 0, "5bce4eab-49de-4271-9d03-cfe9b10c5fd9", "Employee", null, false, false, null, null, "RIOT", null, null, false, new[] { 5, 6, 0 }, "ae4ca387-7992-4d03-a02c-85c7a1f96897", false, "riot" },
                    { "925f70c3-688c-456d-9487-8c57413cbad2", 0, "d201cc80-18ed-43c8-8d90-4ce507748c11", "Employee", null, false, false, null, null, "ZEUS", null, null, false, new[] { 1, 2, 3 }, "d6d97234-3910-4ae3-8b8e-e32ac0132733", false, "zeus" }
                });
        }
    }
}
