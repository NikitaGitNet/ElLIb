using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElLIb.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "f8496749-6a07-4782-8543-39fa702e973c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "3941211d-c5fe-40a8-9c72-6eaf5b5b4da4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8fd2bd9-0a51-4a50-97e3-ac4f09b03b26", "AQAAAAEAACcQAAAAEHpvKFuRfayldhQDZ7dTfkV0TrwoTLrs98+evQ+b4B5xrpnVxtoq3RTqykvHOEDjaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1b64195-0fe2-4e67-84fc-fb48ef07fd6b", "AQAAAAEAACcQAAAAEMAPtRzMyDB7/Y3l15HNnhu79fWv1nPCHygbE2VOPdQrBQg0UZ2bHi5ZytxDBo5gbQ==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 19, 25, 30, 53, DateTimeKind.Utc).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 19, 25, 30, 53, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 19, 25, 30, 53, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 19, 25, 30, 53, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 19, 25, 30, 53, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "ed03e305-bc07-44c6-9ac9-4c1a8afd32c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "aa0e1072-cd3f-4fa7-a042-8b4c00873fff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5cc0812b-c44d-44f3-bc78-704b222c95e7", "AQAAAAEAACcQAAAAEA07qNNq52woLVj/Ft8IoOk1P6N9lFZDWbV9Om6P0HV63pPyPH7kHKZdw5jXY+4ABQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fdfc93fd-2bff-4d9f-9ec5-3687ad879d7b", "AQAAAAEAACcQAAAAEHk4cEyH7p0T7/E7E37RdDzVUGVdUlWLTz3U1L0FeBGf9kiZ66OZeu24HnyiVGf79g==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 17, 26, 23, 542, DateTimeKind.Utc).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 17, 26, 23, 542, DateTimeKind.Utc).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 17, 26, 23, 542, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 17, 26, 23, 542, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 8, 24, 17, 26, 23, 542, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
