using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeKeeper.Migrations
{
    /// <inheritdoc />
    public partial class Schedulemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72e594fb-df43-40ff-abc2-47979b0c6efe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3488933-e220-4e2f-8c17-0aa47df5de02");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Timings");

            migrationBuilder.AddColumn<int[]>(
                name: "Schedule",
                table: "AspNetUsers",
                type: "integer[]",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Schedule", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "82ecc253-584d-400a-94a4-bc417bbaa90a", 0, "5bce4eab-49de-4271-9d03-cfe9b10c5fd9", "Employee", null, false, false, null, null, "RIOT", null, null, false, new[] { 5, 6, 0 }, "ae4ca387-7992-4d03-a02c-85c7a1f96897", false, "riot" },
                    { "925f70c3-688c-456d-9487-8c57413cbad2", 0, "d201cc80-18ed-43c8-8d90-4ce507748c11", "Employee", null, false, false, null, null, "ZEUS", null, null, false, new[] { 1, 2, 3 }, "d6d97234-3910-4ae3-8b8e-e32ac0132733", false, "zeus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82ecc253-584d-400a-94a4-bc417bbaa90a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "925f70c3-688c-456d-9487-8c57413cbad2");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int[]>(
                name: "Schedule",
                table: "Timings",
                type: "integer[]",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "72e594fb-df43-40ff-abc2-47979b0c6efe", 0, "ad0fe893-1ac2-42bc-b8f2-eceed234e704", "Employee", null, false, false, null, null, "RIOT", null, null, false, "da4c04ef-249c-4284-96da-a08d8d2123dd", false, "riot" },
                    { "f3488933-e220-4e2f-8c17-0aa47df5de02", 0, "b78e5189-8b6b-4ad6-97ed-28c1ccdaa50b", "Employee", null, false, false, null, null, "ZEUS", null, null, false, "f806d5b7-3f81-4576-a022-a071ec281f21", false, "zeus" }
                });
        }
    }
}
