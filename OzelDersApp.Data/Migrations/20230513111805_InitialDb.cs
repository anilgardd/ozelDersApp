using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelDersApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Graduation = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeachersBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f3a8f53-9519-4e51-a74f-1acbc4b9aaba", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", null, "Öğrenciler", "Ogrenci", "OGRENCI" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3555), "Matematik Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3558), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3560), "Fizik Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3561), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3562), "Kimya Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3563), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3564), "Biyoloji Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3564), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3565), "Tarih Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3566), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3567), "Coğrafya Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3567), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3568), "İngilizce Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3569), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3570), "Almanca Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3570), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3571), "Fransızca Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3572), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3573), "Felsefe Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3573), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3575), "Müzik Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3575), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3576), "Resim Dersleri", true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(3577), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9234), true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9236), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9237), true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9238), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9239), true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9239), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9240), true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9240), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9241), true, new DateTime(2023, 5, 13, 14, 18, 5, 671, DateTimeKind.Local).AddTicks(9242), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ebdf0fa-5410-48bf-95f4-5facb9df4c36", 0, "Bursa", "de8d5530-8557-4001-94b4-7d78b42116c8", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEKSvCK0Yu32ckkpQMMeSsKPtn33SVbt92kkBwMpfJFZbT9NV3UNA1zj0n4WrRnPm5w==", "5399782513", null, false, "85996f0d-bbd5-4ddb-82b1-58708728bec6", false, "selinkar" },
                    { "480c320e-dfd0-410b-928c-e554b6ce2d92", 0, "Kayseri", "dde1cc18-e7e6-404f-a947-1f6dedfd7b11", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEJ/U7DdnViz1iO4o+2CIQKQFUSt5Ih4xZ5Ps11p9tVJ/rQpi2cHkuXrd0zUVqieEjw==", "5359876543", null, false, "2a9ad9df-fb72-4a16-b75a-1a73e822a50a", false, "kemalkaya" },
                    { "6231d6f0-eb32-49f6-ad34-5f75af075161", 0, "Adana", "bf0b1944-414a-4da3-9a3a-f29c3626d69d", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAEDfgh1G2O3pjhonqNSzVIi1xjWgyiuhlmA7sD3UcFAUJjd5atjmTRZe2nMeQXE7GZg==", "5321234567", null, false, "3c4648cb-76f0-4cf8-b4f2-0573f28b8d03", false, "gokhanaydin" },
                    { "70ddfee1-6dd5-431b-a021-f9886c3d56bd", 0, "Antalya", "f190027e-020e-453e-9162-939de01ab44d", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAENCaLqLeEdDnIxznJ+tEBpd0ce+fLcBHBxNmTfG01UkIJ9kDVu7NVz//cCC1PEK4yg==", "5361234567", null, false, "130dc004-02e2-4d1c-8127-586e2ba6d9af", false, "gulsahin" },
                    { "800dd63e-ac56-4f5c-b017-c203690bcd5f", 0, "Ankara", "95e91875-3a9c-4407-8cd8-e96399d123d7", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEFdqHBP7wlWkrV4K+vswxo43LO7Y/671VVomzpicsGBpX5raSFAFCNQWcORbe+PZKQ==", "5336549872", null, false, "d2e27a48-a11d-4c90-996c-4c35ed1cd6e1", false, "zeynepturk" },
                    { "88b5cedc-987b-4d70-9a91-2d5ace96e249", 0, "Ankara", "bcdefaf4-e52c-4c39-a0b6-3b53559d39e5", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAELeTcgHx47McdzFB1+3JbD7pEaJA19xIennSLVVXSKblQN+Kv3aylWCFqx9oFEXgmQ==", "5551234567", null, false, "23a0b104-ba82-4f8c-b312-dd0181b0037e", false, "ahmetyilmaz" },
                    { "92f692bf-ec2d-45b6-9b3e-39ae6e78459d", 0, "İzmir", "6eaaa98b-2f3f-4762-8b53-01156a12a065", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEA7rNuDsXeFpzhlalnoUxnMteObTts1I1kSU2t0mqArOXBl04x/daCAGfFraLf4CdA==", "5559876543", null, false, "b1cb98fe-e01d-41b7-8ea2-9d497c77afc3", false, "aliyildiz" },
                    { "97ffab8c-7236-4d83-be5b-69a14612f8f1", 0, "İstanbul", "25edf7fe-4d91-472c-8c2a-0f5e0e1cbe3d", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAELJyRWU19NSXe24/ryDwv1G1DiPlxfLaijDGg6Pxk3QwGjk14+tN+wFX6OjxwX5g6Q==", "5379876543", null, false, "14536149-b845-4d19-aa9c-99caac131e42", false, "emreakin" },
                    { "9d9098db-63c1-4ea7-a114-2794baebdf8a", 0, "İstanbul", "1be241f0-d4a3-425e-a0c7-0aacc1607b26", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEDmtlgtWKqmKmJUpBeoKfZqHB6nkFEWNprSXNZ7ECLEZAKTa7w6xPe6fOd+PhH7onw==", "5397891234", null, false, "1a779357-9218-4894-b46a-a04f20f23f16", false, "esraaydin" },
                    { "c14211c3-e49f-4aed-997d-63bd57724a4c", 0, "Bursa", "00b49cb2-3729-4ba9-a563-8ee48a141378", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEHvWpXBbbUxynGFPDonMYVhgusbJhiaFCScxkEwiFXyZ8vufs5sKzWFMlxc6rdY3pw==", "5396542513", null, false, "66eff621-4161-41e0-a6b0-728f163e3392", false, "mehmetkaya" },
                    { "c81ec6bd-40c5-4793-a26a-5d6c1500e040", 0, "İzmir", "dffed302-bbb4-458e-b7f4-08b9d1c4f232", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEHRvSe+ZpTMR8BTHGmAfaq6YkpZpqrLW1jzq2nD9Lt8XnhclbcFM4zWrw8kZVIh+3g==", "5329876543", null, false, "1c28434f-ddb3-451c-ba1f-49060fbb99a9", false, "aysedemir" },
                    { "cfdd6240-1389-4c81-96f2-3115d1ac7037", 0, "Antalya", "2c1437c6-71c4-450a-971d-c418a7e7d0b1", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAECMaILqUpAriEYqHQXhhqemEBxL+3FOI3u/ZUL/RfB1fwy/YzmPh7+w3TB3ZEsvS3Q==", "5423456789", null, false, "04652964-3750-46d2-b1e7-861991295f14", false, "mustafaozkan" },
                    { "d575880b-02de-4e8f-a4bd-cd1c85ad125b", 0, "İstanbul", "8af9071e-7700-46ce-823b-9cf09c564d9c", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAENMC8CkUN2YSaFWwuLtYVkDZv8JnVYccRz5h/idrW//wbg0/S0s9+3Hxf2779BZzUA==", "5387891234", null, false, "fae58f88-8d8c-4d8d-aad9-83ed4cf9e0d1", false, "sevvaldemir" },
                    { "d6e4f8c2-ab85-4472-8a57-b7d3971843c1", 0, "Ankara", "3b53f1ba-1785-40bc-9f80-3f7a51eab689", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEKhKndR6Em+LGhX9Jnq3NhuG+fLDnyvbXRfa/YY8gSWJzLN0TMsgdb6FuZLOx01AtA==", "5323456789", null, false, "96531f73-39bd-4ea5-84d8-ef95fcbc1819", false, "cemyilmaz" },
                    { "d7571beb-5cb5-45bf-abc2-e9b76ad1cd19", 0, "İzmir", "d5f98b8c-c4c5-49a9-babb-42cfc95aad8d", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEPNr0RD4YElHivZyYe08wt3fI2rQuWmjVbzd9iAWbtWSzl0Tmaw7HdXvg9VpVmxwoQ==", "5336549876", null, false, "5481e7d0-3624-4170-b616-0e704ef7230a", false, "mehmetyildiz" },
                    { "db54aaaa-16c7-4145-9640-099bc7b1838b", 0, "Bursa", "eaf554ef-0bd8-4244-aec1-a21b44a080e1", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEPExz6lCrZJQAmQOmBz7z9njztbQbJ+g6Iga6N2TgsERwsl/J9QN19yj1LU2gzJ5+w==", "5399876543", null, false, "614b8d2e-3201-406b-9e15-8156fb93fa38", false, "seymayilmaz" },
                    { "dfdf0094-ff05-40fc-93a7-14ebafa45b71", 0, "İstanbul", "e060e527-bae0-4b60-8487-5b83f2da054f", new DateTime(2000, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "cananelif@hotmail.com", true, "Canan", "Kadın", 5, "Elif", false, null, "CANANELIF@HOTMAIL.COM", "CANANELIF", "AQAAAAIAAYagAAAAEHOjX1jmAHS5euLbG0AqHMpABaeuTag8ZuRhWn2W22ncjultvC59bDSOxLArXEHYfw==", "5555555555", null, false, "faf03eaa-7e60-48fa-9eeb-955bfab67101", false, "cananelif" },
                    { "e53ecfa0-6ce4-40c3-83d1-e8f8d870cca9", 0, "İstanbul", "83de87dd-b3ae-4425-9a39-04bc7b2f447a", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAEHbl76LLz4lJUTn3fPmiVlvQvija/sv+DhaDLXeyT0uEXBz68oWLddwK/cS3KJv/bw==", "5396542513", null, false, "8f3fc63c-a925-42e0-93cf-8cb487b76a81", false, "denizcakir" },
                    { "f09e13c3-7fe8-4f7e-80fc-4508d339ead3", 0, "Adana", "3f28a004-4799-4e2c-bcdb-eb3f3f2485f3", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEPC75O96VDR6k2VDh6MQr4Y86T8Qn0YxErWu91Yh/krmL0R2jpI/Hk/pWz7ds0KwKg==", "5334567890", null, false, "758d34da-ea60-447a-a158-7610a62c1680", false, "fatmasahin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "3ebdf0fa-5410-48bf-95f4-5facb9df4c36" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "480c320e-dfd0-410b-928c-e554b6ce2d92" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "6231d6f0-eb32-49f6-ad34-5f75af075161" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "70ddfee1-6dd5-431b-a021-f9886c3d56bd" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "800dd63e-ac56-4f5c-b017-c203690bcd5f" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "88b5cedc-987b-4d70-9a91-2d5ace96e249" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "92f692bf-ec2d-45b6-9b3e-39ae6e78459d" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "97ffab8c-7236-4d83-be5b-69a14612f8f1" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "9d9098db-63c1-4ea7-a114-2794baebdf8a" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "c14211c3-e49f-4aed-997d-63bd57724a4c" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "c81ec6bd-40c5-4793-a26a-5d6c1500e040" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "cfdd6240-1389-4c81-96f2-3115d1ac7037" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "d575880b-02de-4e8f-a4bd-cd1c85ad125b" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "d6e4f8c2-ab85-4472-8a57-b7d3971843c1" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "d7571beb-5cb5-45bf-abc2-e9b76ad1cd19" },
                    { "665c2083-629a-434b-9fb0-353ec2ee9bb7", "db54aaaa-16c7-4145-9640-099bc7b1838b" },
                    { "3f3a8f53-9519-4e51-a74f-1acbc4b9aaba", "dfdf0094-ff05-40fc-93a7-14ebafa45b71" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "e53ecfa0-6ce4-40c3-83d1-e8f8d870cca9" },
                    { "d01c1e95-3167-4703-bce1-76ce1aedc54e", "f09e13c3-7fe8-4f7e-80fc-4508d339ead3" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "dfdf0094-ff05-40fc-93a7-14ebafa45b71" },
                    { 2, "e53ecfa0-6ce4-40c3-83d1-e8f8d870cca9" },
                    { 3, "88b5cedc-987b-4d70-9a91-2d5ace96e249" },
                    { 4, "c81ec6bd-40c5-4793-a26a-5d6c1500e040" },
                    { 5, "c14211c3-e49f-4aed-997d-63bd57724a4c" },
                    { 6, "f09e13c3-7fe8-4f7e-80fc-4508d339ead3" },
                    { 7, "97ffab8c-7236-4d83-be5b-69a14612f8f1" },
                    { 8, "800dd63e-ac56-4f5c-b017-c203690bcd5f" },
                    { 9, "92f692bf-ec2d-45b6-9b3e-39ae6e78459d" },
                    { 10, "cfdd6240-1389-4c81-96f2-3115d1ac7037" },
                    { 11, "9d9098db-63c1-4ea7-a114-2794baebdf8a" },
                    { 12, "3ebdf0fa-5410-48bf-95f4-5facb9df4c36" },
                    { 13, "d6e4f8c2-ab85-4472-8a57-b7d3971843c1" },
                    { 14, "d575880b-02de-4e8f-a4bd-cd1c85ad125b" },
                    { 15, "d7571beb-5cb5-45bf-abc2-e9b76ad1cd19" },
                    { 16, "70ddfee1-6dd5-431b-a021-f9886c3d56bd" },
                    { 17, "480c320e-dfd0-410b-928c-e554b6ce2d92" },
                    { 18, "6231d6f0-eb32-49f6-ad34-5f75af075161" },
                    { 19, "db54aaaa-16c7-4145-9640-099bc7b1838b" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9151), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9163), null, "e53ecfa0-6ce4-40c3-83d1-e8f8d870cca9" },
                    { 2, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9172), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9173), null, "88b5cedc-987b-4d70-9a91-2d5ace96e249" },
                    { 3, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9174), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9175), null, "c81ec6bd-40c5-4793-a26a-5d6c1500e040" },
                    { 4, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9176), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9177), null, "c14211c3-e49f-4aed-997d-63bd57724a4c" },
                    { 5, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9178), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9178), null, "f09e13c3-7fe8-4f7e-80fc-4508d339ead3" },
                    { 6, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9180), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9181), null, "97ffab8c-7236-4d83-be5b-69a14612f8f1" },
                    { 7, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9182), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9183), null, "800dd63e-ac56-4f5c-b017-c203690bcd5f" },
                    { 8, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9184), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9184), null, "92f692bf-ec2d-45b6-9b3e-39ae6e78459d" },
                    { 9, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9186), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9187), null, "cfdd6240-1389-4c81-96f2-3115d1ac7037" },
                    { 10, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9189), true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9189), null, "9d9098db-63c1-4ea7-a114-2794baebdf8a" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9228), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9229), null, "3ebdf0fa-5410-48bf-95f4-5facb9df4c36" },
                    { 2, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9236), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9237), null, "d6e4f8c2-ab85-4472-8a57-b7d3971843c1" },
                    { 3, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9238), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9239), null, "d575880b-02de-4e8f-a4bd-cd1c85ad125b" },
                    { 4, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9241), "Ege Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9241), null, "d7571beb-5cb5-45bf-abc2-e9b76ad1cd19" },
                    { 5, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9242), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9243), null, "70ddfee1-6dd5-431b-a021-f9886c3d56bd" },
                    { 6, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9245), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9245), null, "480c320e-dfd0-410b-928c-e554b6ce2d92" },
                    { 7, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9246), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9247), null, "6231d6f0-eb32-49f6-ad34-5f75af075161" },
                    { 8, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9248), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 13, 14, 18, 4, 411, DateTimeKind.Local).AddTicks(9249), null, "db54aaaa-16c7-4145-9640-099bc7b1838b" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 13, 14, 18, 5, 669, DateTimeKind.Local).AddTicks(9912), "dsdasd", true, 45m, 4, new DateTime(2023, 5, 13, 14, 18, 5, 669, DateTimeKind.Local).AddTicks(9919), "dsdds" });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 6, 3 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "TeachersBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BranchId",
                table: "Adverts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AdvertId",
                table: "CartItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AdvertId",
                table: "OrderItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeachersBranches_BranchId",
                table: "TeachersBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TeachersBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
