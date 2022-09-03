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
                value: "9d04cbbd-d3b7-4e39-916b-1719f6bc0c33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "552584f6-d410-42b4-b1ec-b45db88845f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d15b5d75-cbc7-4304-a142-12200a7c6f38", "AQAAAAEAACcQAAAAEJi597s19dBsmrsrU0qMKEIYBgPdzKtkoOsD8IiGp8XB+jR4Uc8JqaQrR+tmUQ7VYQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb66526c-d8bb-44c3-995d-6b6059e8cd15", "AQAAAAEAACcQAAAAEI5r4IyrQ/pm2kf64yBniKylDqroAEHpSDngLra50pLkvhuUMfBRNyy6brnUTUXWjw==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 3, 20, 39, 21, 641, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 3, 20, 39, 21, 641, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 3, 20, 39, 21, 641, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 3, 20, 39, 21, 641, DateTimeKind.Utc).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 3, 20, 39, 21, 641, DateTimeKind.Utc).AddTicks(3918));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "a0d1eaf4-414a-4710-a8f0-9a2750b0d952");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "d06a2d1f-70c2-4d4b-9722-701a5fbf1a4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7cf2b4f9-9073-45bb-8158-58786da8e711", "AQAAAAEAACcQAAAAEE8J/02C+scNfJ9S/v164aATswblKBZLMddXI4+ZbT8UyLvop5OR+dX/WbZH+V6XBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db6b4600-7195-4845-b317-9ac5ec8f2ac3", "AQAAAAEAACcQAAAAEDFNwNHi7emPQ1ZIWhoQHgmnTnZvhq5cWlXb6Ot2xhxQAkLkFNAZmxpU4u1vzWAh6Q==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 2, 17, 49, 23, 505, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 2, 17, 49, 23, 505, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 2, 17, 49, 23, 505, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 2, 17, 49, 23, 505, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 2, 17, 49, 23, 505, DateTimeKind.Utc).AddTicks(6719));
        }
    }
}
