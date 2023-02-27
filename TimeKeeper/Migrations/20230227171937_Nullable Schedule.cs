using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeKeeper.Migrations
{
    /// <inheritdoc />
    public partial class NullableSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fc32a25-df05-47f2-97ff-3d65c51415b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af44d2b5-a6eb-4cfa-8091-fa64550327a5");

            migrationBuilder.AlterColumn<int[]>(
                name: "Schedule",
                table: "Timings",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "72e594fb-df43-40ff-abc2-47979b0c6efe", 0, "ad0fe893-1ac2-42bc-b8f2-eceed234e704", "Employee", null, false, false, null, null, "RIOT", null, null, false, "da4c04ef-249c-4284-96da-a08d8d2123dd", false, "riot" },
                    { "f3488933-e220-4e2f-8c17-0aa47df5de02", 0, "b78e5189-8b6b-4ad6-97ed-28c1ccdaa50b", "Employee", null, false, false, null, null, "ZEUS", null, null, false, "f806d5b7-3f81-4576-a022-a071ec281f21", false, "zeus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72e594fb-df43-40ff-abc2-47979b0c6efe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3488933-e220-4e2f-8c17-0aa47df5de02");

            migrationBuilder.AlterColumn<int[]>(
                name: "Schedule",
                table: "Timings",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fc32a25-df05-47f2-97ff-3d65c51415b6", 0, "c0e42e82-0143-474d-a66c-3c8ca4ccbfa4", "Employee", null, false, false, null, null, "ZEUS", null, null, false, "40f0452e-10b6-475c-a56b-fe98b6f95a62", false, "zeus" },
                    { "af44d2b5-a6eb-4cfa-8091-fa64550327a5", 0, "73bb8fc0-3eb3-4c44-a486-376df30d4553", "Employee", null, false, false, null, null, "RIOT", null, null, false, "1359c106-4b48-490f-b0eb-731fd66d50fb", false, "riot" }
                });
        }
    }
}
