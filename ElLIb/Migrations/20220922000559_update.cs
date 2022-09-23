using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElLIb.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "516c54d8-e33f-4c23-9c8d-18cc704329e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "1d1c42ab-b972-47b5-833b-104ba09a4265");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "aaa5ced4-1532-430d-ab2c-872415a234cc", new DateTime(2022, 9, 22, 3, 5, 59, 228, DateTimeKind.Local).AddTicks(5449), "AQAAAAEAACcQAAAAEM+mgBBVlGf6BpjAc26hVxQ98mDqzcKopqAJwz+GbKvc9P5Me8Fg1NgfvXReeE+cvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "81ec2cc8-dcc5-4abe-b808-db8cc429ac97", new DateTime(2022, 9, 22, 3, 5, 59, 230, DateTimeKind.Local).AddTicks(8182), "AQAAAAEAACcQAAAAELo/Lm3BNhePTTB30a6J2Pq6kHJohdRUWdg+FezahnncbhMWUmO+LdAQrR9sbwSHmA==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 22, 0, 5, 59, 231, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 22, 0, 5, 59, 231, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 22, 0, 5, 59, 231, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 22, 0, 5, 59, 231, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 22, 0, 5, 59, 231, DateTimeKind.Utc).AddTicks(1737));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "3951c3f4-dc7e-4b0e-ad59-4697eaee4383");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "ba860d6e-55d5-4e99-952a-15e7930ab9a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "834f6371-f213-44f0-98b8-f3783d6a66bb", new DateTime(2022, 9, 20, 19, 24, 35, 31, DateTimeKind.Local).AddTicks(698), "AQAAAAEAACcQAAAAEEm1km9oChOZbC6H8SWNzueBFAIkhZPXk5DXKDlFmsyY+G3CqsZzfFoTQpAlsfjYcQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "85cbe063-d02f-4328-b792-115b4a9f2033", new DateTime(2022, 9, 20, 19, 24, 35, 34, DateTimeKind.Local).AddTicks(118), "AQAAAAEAACcQAAAAEE8gXgxaUo1VI6ujRp7j4yyTzPUnnq2hFZc+clCIKlUxjF+pEXQxbV/7J++VdxsfjQ==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 20, 16, 24, 35, 34, DateTimeKind.Utc).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 20, 16, 24, 35, 34, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 20, 16, 24, 35, 34, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 20, 16, 24, 35, 34, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 20, 16, 24, 35, 34, DateTimeKind.Utc).AddTicks(3697));
        }
    }
}
