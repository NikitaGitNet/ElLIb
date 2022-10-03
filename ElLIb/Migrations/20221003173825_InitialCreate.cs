﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ElLIb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeWord = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    SubTitle = table.Column<string>(type: "text", nullable: true),
                    TitleImagePath = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "text", nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaKeywords = table.Column<string>(type: "text", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SubTitle = table.Column<string>(type: "text", nullable: true),
                    IsBooking = table.Column<bool>(type: "boolean", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    AuthorName = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreName = table.Column<string>(type: "text", nullable: true),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false),
                    TitleImagePath = table.Column<string>(type: "text", nullable: true),
                    MetaTitle = table.Column<string>(type: "text", nullable: true),
                    MetaDescription = table.Column<string>(type: "text", nullable: true),
                    MetaKeywords = table.Column<string>(type: "text", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IssueBooking = table.Column<bool>(type: "boolean", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksTitle = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingValue = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e84bf2c-585f-42dc-a868-73157016ec70", "4be68794-011b-413f-adbf-a6b4398e2e58", "moderator", "MODERATOR" },
                    { "8af10569-b018-4fe7-a380-7d6a14c70b74", "88095d1b-d032-42e0-8004-7f8609b81d3f", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateOn", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b62472e-4f66-49fa-a20f-e7685b9565d8", 0, "3e247dbb-35f7-4b0e-b7b1-1ce086d00b19", new DateTime(2022, 10, 3, 20, 38, 24, 822, DateTimeKind.Local).AddTicks(794), "my@email.com", true, false, null, "MY@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEHjBKqpoL8S6W6HS2PAv1beIwphmCdzggFRbWXPzKPN451bIcgH+GkDPR1AW+1F60A==", null, false, "", false, "admin" },
                    { "86d55f40-9544-4d92-aa24-cc5693a5fd96", 0, "c5c217b1-8f2d-438c-9c6f-2204143252d1", new DateTime(2022, 10, 3, 20, 38, 24, 824, DateTimeKind.Local).AddTicks(4729), "moderator@email.com", true, false, null, "MODERATOR@EMAIL.COM", "MODERATOR", "AQAAAAEAACcQAAAAELVRhhJ/EIE3Nil/KLga0zZpS7V1+kRnm83kVQQoaeLQCHTBO5KE2TkU0pyLaiknfA==", null, false, "", false, "moderator" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ff9b30ce-ad2e-48ce-b811-e45481b55043"), "Жафаров Ильнур" },
                    { new Guid("a9cfc2d7-f079-4205-8750-c48acbd2f231"), "Себастьян Жондо" },
                    { new Guid("b573b21d-544f-4072-a595-b427b54247a2"), "Джон Перкинс" },
                    { new Guid("5ac34184-f039-43da-8594-35e33c820882"), "Дмитрий Шелег" },
                    { new Guid("549ceae8-770c-4cd1-8ca8-c7f13bd7ba64"), "Николай Свечин" },
                    { new Guid("3f40c815-4d3f-42f7-92e8-10543306465f"), "Алексей Гришин" },
                    { new Guid("3cbe84ba-9744-4cef-9dd9-815c7c53e133"), "Сергей Лукьяненко" },
                    { new Guid("c07ada61-d847-43eb-b2eb-8e32adcd64f4"), "Букин Генадий" },
                    { new Guid("ee09b74a-99ff-4f41-a04b-5957c2d8c3b6"), "Эрих Мария Ремарк" },
                    { new Guid("7785baef-d027-4c00-be4f-237846c9c318"), "Артур Конан Дойл" },
                    { new Guid("a40e7075-54fc-4015-9488-1b32652b96e4"), "Олдос Хаксли" },
                    { new Guid("afe48adb-b2a8-4d40-aef2-2816ec837304"), "Валентин Катаев" },
                    { new Guid("1198ab8d-59e8-4ce8-a4ee-98cce1f65eec"), "Рей Брэдбери" },
                    { new Guid("33a9c3e4-be82-40dd-8c06-4f29b0ac732a"), "Захар Петров" },
                    { new Guid("2acdaae8-d1ce-4995-bc07-537f77cc74bc"), "Айн Рэнд" },
                    { new Guid("0bf3eaaa-107f-434e-85bc-49653b07515a"), "Неизвестный автор" },
                    { new Guid("bb1a20f6-4406-4fe3-bf82-b3b31453667b"), "Стивен Кинг" },
                    { new Guid("a6ffa373-2b5a-424e-b5ed-835678fd0d92"), "Джордж Оруэл" },
                    { new Guid("ebcbdb38-9d81-4cba-9f6b-b0edb5d6bffa"), "Уильям Голдинг" },
                    { new Guid("65b1fd9e-36d4-4965-bd3f-66a3e4859426"), "Наиль Выборнов" },
                    { new Guid("4f91476b-4021-4581-b729-78c8fede5d3f"), "Дмитрий Глуховский" },
                    { new Guid("9c37a892-1e81-4120-b8be-de6833215e67"), "Василий Орехов" },
                    { new Guid("d695cfa5-04cd-40ac-b0d7-307a8a876860"), "Андрей Левицкий" },
                    { new Guid("30254b73-712a-48d4-bf0b-412216a90ade"), "Вячеслав Шалыгин" },
                    { new Guid("fa10b14c-e352-4eac-91ae-982cb3fd3982"), "Роман Глушков" },
                    { new Guid("e5c68c75-9b15-4424-b062-b91c7f4b6332"), "Габриэль Гарсиа" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"), "Хоррор" },
                    { new Guid("c500c41b-6b66-424b-b8d8-bf88e8f76a9e"), "Детектив" },
                    { new Guid("87bbe432-9779-4488-a769-0c067a65aecd"), "Приключения" },
                    { new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика" },
                    { new Guid("008fb99c-c826-4ee2-bf89-e60f1ffaf6a9"), "Научная литература" },
                    { new Guid("e5372338-ee97-408b-82c2-ab7e3ca6d145"), "Неизвестный жанр" },
                    { new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "Id", "CodeWord", "DateAdded", "MetaDescription", "MetaKeywords", "MetaTitle", "SubTitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"), "PageIndex", new DateTime(2022, 10, 3, 17, 38, 24, 824, DateTimeKind.Utc).AddTicks(6525), null, null, null, null, "<h2>Добро пожаловать в нашу библиотеку</h2><p>Эта <strong>Библиотека</strong> лучшая в мире и это не только мое мнение. Наша задача сделать литературу доступной для всех желающих. Предлагаем вам пройти регистрацию и начать пользоваться</p>", "Главная", null },
                    { new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"), "PageBooks", new DateTime(2022, 10, 3, 17, 38, 24, 824, DateTimeKind.Utc).AddTicks(8552), null, null, null, null, "Сейчас здесь пусто, содержание заполняется администратором", "Книги", null },
                    { new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"), "PageContacts", new DateTime(2022, 10, 3, 17, 38, 24, 824, DateTimeKind.Utc).AddTicks(8589), null, null, null, null, "<h2>Мои контакты</h2><p>Почта: cr.xeller@mail.ru</p><p>Телеграм: @NikitaGitNet</p>", "Контакты", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5e84bf2c-585f-42dc-a868-73157016ec70", "86d55f40-9544-4d92-aa24-cc5693a5fd96" },
                    { "8af10569-b018-4fe7-a380-7d6a14c70b74", "3b62472e-4f66-49fa-a20f-e7685b9565d8" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AuthorName", "DateAdded", "GenreId", "GenreName", "IsBooking", "MetaDescription", "MetaKeywords", "MetaTitle", "SubTitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("213f74db-5ffd-4123-bd8c-e07c63c02c03"), new Guid("a9cfc2d7-f079-4205-8750-c48acbd2f231"), "Себастьян Жондо", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2690), new Guid("e5372338-ee97-408b-82c2-ab7e3ca6d145"), "Неизвестный жанр", false, null, null, null, "А как у него дела, кст?", "Я хз, он не говорит", "Как дела, дорогой Карл?", "67985997-virzhini-muza-kak-dela-dorogoy-karl-otkrovennye-memuary-telohranitelya-kar.webp" },
                    { new Guid("94271f11-d6b7-43a8-b516-1b0f78f5cf10"), new Guid("b573b21d-544f-4072-a595-b427b54247a2"), "Джон Перкинс", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2665), new Guid("008fb99c-c826-4ee2-bf89-e60f1ffaf6a9"), "Научная литература", false, null, null, null, "Про загнивающий запад", "Обэма во всем виноват", "Исповедь экономического убийцы", "132973-dzhon-perkins-ispoved-ekonomicheskogo-ubiycy.webp" },
                    { new Guid("19f4d611-5a6a-4cf1-bcde-02e85081bb18"), new Guid("549ceae8-770c-4cd1-8ca8-c7f13bd7ba64"), "Николай Свечин", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2614), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Российская классика", "Даже не знаю, чем они там могли заняться, с работы раньше ушли наверное...", "В отсутствие начальства", "67922364-nikolay-svechin-v-otsutstvie-nachalstva.webp" },
                    { new Guid("c3922ccf-dcfa-4c35-90bc-cc9dbc5e8902"), new Guid("a6ffa373-2b5a-424e-b5ed-835678fd0d92"), "Джордж Оруэл", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2509), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Лучшее что я читал", "После себя оставляет ощущение опустошенности и безысходности", "1984", "67281231--.webp" },
                    { new Guid("8638a5fa-e30d-41a0-9db2-1493d38044eb"), new Guid("1198ab8d-59e8-4ce8-a4ee-98cce1f65eec"), "Рей Брэдбери", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2480), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "По сути книга про то, к чему стремится наша поп культура", "Мне не очень зашла", "451 градус по фарингейту", "39507162--.webp" },
                    { new Guid("9326fb09-8557-4cdf-a2e5-6a3cf65ff252"), new Guid("ee09b74a-99ff-4f41-a04b-5957c2d8c3b6"), "Эрих Мария Ремарк", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2456), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Про фронт книга", "Нет, не про фронэнд", "На западном фронте без перемен", "32878920-erih-mariya-remark-na-zapadnom-fronte-bez-peremen-32878920.webp" },
                    { new Guid("ba3af0e2-6a4c-4070-aa0c-0ffc0027d60f"), new Guid("a6ffa373-2b5a-424e-b5ed-835678fd0d92"), "Джордж Оруэл", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2383), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Книга о дескридетирующая коммунистический строй", "Неплохо", "Скотный двор", "19258232--.webp" },
                    { new Guid("893ed244-ed74-4618-b101-3e88b726d128"), new Guid("a40e7075-54fc-4015-9488-1b32652b96e4"), "Олдос Хаксли", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2359), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Это шедевр!!!", "Книга в свое время перевернувшая мое представление о совершенном мире", "О дивный новый мир", "14332383-oldos-leonard-haksli-o-divnyy-novyy-mir.webp" },
                    { new Guid("1b12fa4b-ad1a-45e1-ba9a-c67ea054e317"), new Guid("afe48adb-b2a8-4d40-aef2-2816ec837304"), "Валентин Катаев", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2288), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Про мальчика", "В полке мальчик был", "Сын полка", "8217563-valentin-kataev-syn-polka-8217563.webp" },
                    { new Guid("058b6f8f-b5c6-4b4f-9124-2c213cb3edfa"), new Guid("33a9c3e4-be82-40dd-8c06-4f29b0ac732a"), "Айн Рэнд", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2215), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Про атланта", "Ну там то про то, то про это", "Атлант расправил плечи", "4236675-ayn-rend-atlant-raspravil-plechi.webp" },
                    { new Guid("ba99c9bb-23fb-4238-8491-f11101b8b6fa"), new Guid("e5c68c75-9b15-4424-b062-b91c7f4b6332"), "Габриэль Гарсиа", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2018), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "Про патриарха осенью", "Что такое осень...", "Осень патриарха", "119586-gabriel-garsia-markes-44998-osen-patriarha.webp" },
                    { new Guid("f59c2a21-0f24-469a-b7cc-495146124310"), new Guid("ebcbdb38-9d81-4cba-9f6b-b0edb5d6bffa"), "Уильям Голдинг", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(1992), new Guid("79500809-b481-49a6-aeb6-869b86f9901e"), "Мировая классика", false, null, null, null, "История о мальчиках на острове", "Муха делает ж-ж-ж-ж-ж-ж-ж-ж-ж-ж", "Повелитель мух", "119029-uilyam-golding-povelitel-muh-119029.webp" },
                    { new Guid("d0528761-f101-4f4f-b0fc-0a970a2026bd"), new Guid("3f40c815-4d3f-42f7-92e8-10543306465f"), "Алексей Гришин", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2589), new Guid("87bbe432-9779-4488-a769-0c067a65aecd"), "Приключения", false, null, null, null, "Типичный попаданец", "Конкретно эту не читал, но у попаданцев в целом 30/70 - хорошие/плохие книги", "Выбор из худшего", "67891001-aleksey-grishin-vybor-iz-hudshego.webp" },
                    { new Guid("50259038-7e6f-402e-a80a-4a85a9cf8afe"), new Guid("3cbe84ba-9744-4cef-9dd9-815c7c53e133"), "Сергей Лукьяненко", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2532), new Guid("87bbe432-9779-4488-a769-0c067a65aecd"), "Приключения", false, null, null, null, "Наверное про то как волотер провел лето", "Не читал, не знаю о чем она", "Лето волонтера", "67385403-sergey-lukyanenko-leto-volontera.webp" },
                    { new Guid("0b6dbc1a-0ab8-4e00-b620-bf517abe8789"), new Guid("7785baef-d027-4c00-be4f-237846c9c318"), "Артур Конан Дойл", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2408), new Guid("c500c41b-6b66-424b-b8d8-bf88e8f76a9e"), "Детектив", false, null, null, null, "Классический детектив", "Неплохо", "Шерлок Холмс", "23571677-arthur-konan-doyle-ves-sherlok-holms.webp" },
                    { new Guid("c0a214e6-aa17-40ad-90fe-e1f465022102"), new Guid("bb1a20f6-4406-4fe3-bf82-b3b31453667b"), "Стивен Кинг", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2335), new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"), "Хоррор", false, null, null, null, "Про киллера", "Аудиокнига у Булдакова еще не вышла, а печатную читать нет времени", "Билли Саммерс", "67303161-stiven-king-billi-sammers.webp" },
                    { new Guid("45723e77-c301-4ac5-b6bc-2f5561fe453e"), new Guid("bb1a20f6-4406-4fe3-bf82-b3b31453667b"), "Стивен Кинг", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2312), new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"), "Хоррор", false, null, null, null, "Вот нашел, забрал себе", "Вроде норм, не читал", "Кто нашел, берет себе", "12483328-stiven-king-kto-nashel-beret-sebe-12483328.webp" },
                    { new Guid("e89bd603-cda2-4bad-94d7-68862640a58d"), new Guid("bb1a20f6-4406-4fe3-bf82-b3b31453667b"), "Стивен Кинг", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2264), new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"), "Хоррор", false, null, null, null, "Про башню наверн", "Ну там Рендал Флегг есть", "Темная башня", "4887784-stiven-king-temnaya-bashnya.webp" },
                    { new Guid("8236e6e4-f03c-48ff-849a-a1e7d0d48cae"), new Guid("bb1a20f6-4406-4fe3-bf82-b3b31453667b"), "Стивен Кинг", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2240), new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"), "Хоррор", false, null, null, null, "Про изоляцию людей под куполом", "Я ожидал большего от книги, честно говоря", "Под куполом", "4387285-stiven-king-pod-kupolom.webp" },
                    { new Guid("85b7a108-6e59-43ec-946f-39baf40d49fe"), new Guid("65b1fd9e-36d4-4965-bd3f-66a3e4859426"), "Наиль Выборнов", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2432), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Про метро", "Классика вселенной метро", "Переход", "23789586-nail-vybornov-metro-2033-perehod.webp" },
                    { new Guid("1cb4916a-5755-4784-bed0-a69db6311504"), new Guid("33a9c3e4-be82-40dd-8c06-4f29b0ac732a"), "Захар Петров", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2146), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Про метро", "Классика вселенной метро", "Муос", "3748275-zahar-petrov-muos.webp" },
                    { new Guid("ebb65c65-bac4-4215-8c4b-dcda8faa6e25"), new Guid("fa10b14c-e352-4eac-91ae-982cb3fd3982"), "Роман Глушков", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2123), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Сталкер", "Классика вселенной сталкер", "Свинцовый закат", "172514-roman-glushkov-svincovyy-zakat-172514.webp" },
                    { new Guid("e895336e-deb2-4a70-a5b6-38cbd1501507"), new Guid("d695cfa5-04cd-40ac-b0d7-307a8a876860"), "Андрей Левицкий", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2099), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Сталкер", "Классика вселенной сталкер", "Сердце зоны", "165057-andrey-levickiy-serdce-zony.webp" },
                    { new Guid("629555f5-a728-4d49-b9c5-754e06c5baef"), new Guid("9c37a892-1e81-4120-b8be-de6833215e67"), "Василий Орехов", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2074), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Сталкер", "Классика вселенной сталкер", "Зона поражения", "152893-vasiliy-orehov-zona-porazheniya.webp" },
                    { new Guid("814f9c1c-9fef-42ba-acbe-857e234f31a8"), new Guid("4f91476b-4021-4581-b729-78c8fede5d3f"), "Дмитрий Глуховский", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2045), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Про метро", "Классика вселенной метро", "Метро 2033", "128391-dmitriy-gluhovskiy-metro-2033.webp" },
                    { new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"), new Guid("c07ada61-d847-43eb-b2eb-8e32adcd64f4"), "Букин Генадий", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(1956), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Там тоже была ересь", "Ваха 40к", "Ересь Хоруса: История Ангрона", "1655641009118970804.jpg" },
                    { new Guid("8fbc3dd1-8d19-454e-8aa3-a31749ea66be"), new Guid("5ac34184-f039-43da-8594-35e33c820882"), "Дмитрий Шелег", new DateTime(2022, 10, 3, 17, 38, 24, 825, DateTimeKind.Utc).AddTicks(2638), new Guid("c500c41b-6b66-424b-b8d8-bf88e8f76a9e"), "Детектив", false, null, null, null, "Один истинный, остальные ложные", "Ну там сначала ложный был, потом истинный появился", "Истинный князь", "68010554-dmitriy-vitalevich-sheleg-istinnyy-knyaz.webp" },
                    { new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"), new Guid("ff9b30ce-ad2e-48ce-b811-e45481b55043"), "Жафаров Ильнур", new DateTime(2022, 10, 3, 17, 38, 24, 824, DateTimeKind.Utc).AddTicks(9029), new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"), "Фантастика", false, null, null, null, "Там ересь была", "Ваха 40к", "Ересь Хоруса", "1655641005121914702.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookId",
                table: "Bookings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TextFields");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
