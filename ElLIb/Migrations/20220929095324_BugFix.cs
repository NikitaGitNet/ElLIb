using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElLIb.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "6bd7fded-5732-4d90-a705-1ecfb4c1e2c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "056684e3-1c89-48c5-b457-294c7a27c753");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "d70edc77-91b3-4d0d-accc-6c65782be06a", new DateTime(2022, 9, 29, 12, 53, 23, 527, DateTimeKind.Local).AddTicks(191), "AQAAAAEAACcQAAAAEISICWJzbAU0XZJBcNILT4pOrnmhxNWkhvUlFK72sGf7WfBDeJ2R+kiQad7pAYnE0Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "3d676ba3-bdac-401c-938e-72751c9206b4", new DateTime(2022, 9, 29, 12, 53, 23, 529, DateTimeKind.Local).AddTicks(1249), "AQAAAAEAACcQAAAAEO6rEH7j2viVAM1RO6Eaj0enK12087babikNyenxaTkrirRl54nYDND/qJTCH5oWYQ==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("058b6f8f-b5c6-4b4f-9124-2c213cb3edfa"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0b6dbc1a-0ab8-4e00-b620-bf517abe8789"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("19f4d611-5a6a-4cf1-bcde-02e85081bb18"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1b12fa4b-ad1a-45e1-ba9a-c67ea054e317"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1cb4916a-5755-4784-bed0-a69db6311504"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("213f74db-5ffd-4123-bd8c-e07c63c02c03"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("45723e77-c301-4ac5-b6bc-2f5561fe453e"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("50259038-7e6f-402e-a80a-4a85a9cf8afe"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("629555f5-a728-4d49-b9c5-754e06c5baef"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("814f9c1c-9fef-42ba-acbe-857e234f31a8"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8236e6e4-f03c-48ff-849a-a1e7d0d48cae"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("85b7a108-6e59-43ec-946f-39baf40d49fe"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8638a5fa-e30d-41a0-9db2-1493d38044eb"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("893ed244-ed74-4618-b101-3e88b726d128"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8fbc3dd1-8d19-454e-8aa3-a31749ea66be"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9326fb09-8557-4cdf-a2e5-6a3cf65ff252"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("94271f11-d6b7-43a8-b516-1b0f78f5cf10"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ba3af0e2-6a4c-4070-aa0c-0ffc0027d60f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ba99c9bb-23fb-4238-8491-f11101b8b6fa"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c0a214e6-aa17-40ad-90fe-e1f465022102"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c3922ccf-dcfa-4c35-90bc-cc9dbc5e8902"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d0528761-f101-4f4f-b0fc-0a970a2026bd"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e895336e-deb2-4a70-a5b6-38cbd1501507"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e89bd603-cda2-4bad-94d7-68862640a58d"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ebb65c65-bac4-4215-8c4b-dcda8faa6e25"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f59c2a21-0f24-469a-b7cc-495146124310"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 53, 23, 529, DateTimeKind.Utc).AddTicks(4905));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e84bf2c-585f-42dc-a868-73157016ec70",
                column: "ConcurrencyStamp",
                value: "1c5e1ec8-f6bd-46c4-a678-79179bda9ebd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "80e43420-5770-4453-84ab-b4cb3f2322dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "d1edfe7d-b851-4565-8528-41f9b45bd2c5", new DateTime(2022, 9, 29, 12, 6, 18, 752, DateTimeKind.Local).AddTicks(1022), "AQAAAAEAACcQAAAAEDCiT5wH7ojvLIuoJpL+nnN6uUrbgacl5rf4iMdG2BJLh1K0HtXGoOruXwFv3Dk7YA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                columns: new[] { "ConcurrencyStamp", "CreateOn", "PasswordHash" },
                values: new object[] { "901b9e7f-8818-4276-9ecd-7983aa17bddf", new DateTime(2022, 9, 29, 12, 6, 18, 754, DateTimeKind.Local).AddTicks(8042), "AQAAAAEAACcQAAAAEFIrpN64QbUyq/nWevf4zOO3PcWymnlEHxwOzhSWvBcZG7JHazk0PAIW5/a4cc+9TA==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("058b6f8f-b5c6-4b4f-9124-2c213cb3edfa"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0b6dbc1a-0ab8-4e00-b620-bf517abe8789"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("19f4d611-5a6a-4cf1-bcde-02e85081bb18"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1b12fa4b-ad1a-45e1-ba9a-c67ea054e317"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1cb4916a-5755-4784-bed0-a69db6311504"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("213f74db-5ffd-4123-bd8c-e07c63c02c03"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("45723e77-c301-4ac5-b6bc-2f5561fe453e"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("50259038-7e6f-402e-a80a-4a85a9cf8afe"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("629555f5-a728-4d49-b9c5-754e06c5baef"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("814f9c1c-9fef-42ba-acbe-857e234f31a8"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8236e6e4-f03c-48ff-849a-a1e7d0d48cae"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("85b7a108-6e59-43ec-946f-39baf40d49fe"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8638a5fa-e30d-41a0-9db2-1493d38044eb"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("893ed244-ed74-4618-b101-3e88b726d128"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8fbc3dd1-8d19-454e-8aa3-a31749ea66be"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9326fb09-8557-4cdf-a2e5-6a3cf65ff252"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("94271f11-d6b7-43a8-b516-1b0f78f5cf10"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ba3af0e2-6a4c-4070-aa0c-0ffc0027d60f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ba99c9bb-23fb-4238-8491-f11101b8b6fa"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c0a214e6-aa17-40ad-90fe-e1f465022102"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c3922ccf-dcfa-4c35-90bc-cc9dbc5e8902"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d0528761-f101-4f4f-b0fc-0a970a2026bd"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e895336e-deb2-4a70-a5b6-38cbd1501507"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e89bd603-cda2-4bad-94d7-68862640a58d"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ebb65c65-bac4-4215-8c4b-dcda8faa6e25"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f59c2a21-0f24-469a-b7cc-495146124310"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 754, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 9, 29, 9, 6, 18, 755, DateTimeKind.Utc).AddTicks(1769));
        }
    }
}
