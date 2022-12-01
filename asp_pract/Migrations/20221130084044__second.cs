using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_pract.Migrations
{
    public partial class _second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageForAdmin",
                table: "NewsItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAdress",
                table: "NewsItems",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9245fe4a-d402-451c-b9ed-9c1a04247482",
                column: "ConcurrencyStamp",
                value: "b2a46300-073a-4afb-9ec7-64a74f943b4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9245fe4a-d402-451c-b9ed-9c1a04247481",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1f70426-c854-417e-952a-9b3fbfefce6b", "AQAAAAEAACcQAAAAEEaIhVuqPIQqYqN8yKaAmzZdgsMeNWEhaBIlVlxU8nikdTrZYk50fhk8Lp67AfoMrg==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247258"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 30, 8, 40, 43, 507, DateTimeKind.Utc).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247369"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 30, 8, 40, 43, 507, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247547"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 30, 8, 40, 43, 507, DateTimeKind.Utc).AddTicks(8861));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageForAdmin",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "UserAdress",
                table: "NewsItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9245fe4a-d402-451c-b9ed-9c1a04247482",
                column: "ConcurrencyStamp",
                value: "ed97d02f-62b6-4267-a5fa-8f1289a03fa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9245fe4a-d402-451c-b9ed-9c1a04247481",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "516a6eb6-8b33-416e-bb26-2b78e2296ad9", "AQAAAAEAACcQAAAAEOX/ABJURybWIFHzaSd2NnNfbflXjvZP6yF11d7cnt/QWsMYRdEpq2G78F4sNBVH5w==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247258"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 28, 8, 12, 5, 120, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247369"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 28, 8, 12, 5, 120, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247547"),
                column: "DateAdded",
                value: new DateTime(2022, 11, 28, 8, 12, 5, 120, DateTimeKind.Utc).AddTicks(6563));
        }
    }
}
