using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebManageImage.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLike = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    ImageStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsDeny = table.Column<bool>(type: "bit", nullable: false),
                    IsLike = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLike = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.ImageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b4613c7-e6a6-4e5b-917e-7d0fd100d031", "4189b611-486a-4157-8550-23c208a9e731", "User", "USER" },
                    { "2d7d45dc-0f7a-4ca1-b444-d1f06160028d", "893004c6-4e5b-4202-821f-fc8d321e3cd6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Ảnh thiên nhiên" },
                    { 2, "Ảnh chân dung" },
                    { 3, "Ảnh động vật" },
                    { 4, "Ảnh gợi cảm" },
                    { 5, "Ảnh học sinh" },
                    { 6, "Ảnh di sản" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CategoryId", "CommentCount", "DateCreate", "Desciption", "ImageStatus", "IsApproval", "IsDeny", "IsLike", "LikeCount", "Name", "Url", "UserId", "UserName", "ViewsCount" },
                values: new object[,]
                {
                    { 2, 1, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rừng nhiệt đới với những tán cây xanh mát đang phát triển vào mùa mưa", true, true, false, false, 24, "Rừng nhiệt đới", "../../assets/Img/rungnhietdoi.jpeg", null, "Ân Phạm", 36 },
                    { 5, 1, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng hôn đang buông xuống vào buổi chiều trông thật đẹp", true, true, false, false, 27, "Hoàng hôn", "../../assets/Img/hoanghon.jpeg", null, "Ân Phạm", 37 },
                    { 8, 1, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dòng sông quê em lúc nào cũng mênh mông con nước, cá tôm rất nhiều", true, true, false, false, 54, "Dòng sông quê em", "../../assets/Img/dongsongqueem.jpeg", null, "Ân Phạm", 77 },
                    { 10, 1, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vịnh Hạ Long một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam", true, true, false, false, 88, "Vịnh Hạ Long", "../../assets/Img/vinhhalong.jpeg", null, "Ân Phạm", 134 },
                    { 11, 1, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vịnh Hạ Long một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam", true, true, false, false, 18, "Sa mạc Sahara", "../../assets/Img/sahara.jpeg", null, "Ân Phạm", 72 },
                    { 3, 2, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cô gái miền tây trong chiếc áo bà ba thước tha", true, true, false, false, 46, "Con gái miền tây", "../../assets/Img/congaimientay.jpeg", null, "Ân Phạm", 55 },
                    { 1, 3, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chó corgi đang chơi đùa ngoài vườn", true, true, false, false, 48, "Chó Corgi", "../../assets/Img/chocogri.jpeg", null, "Ân Phạm", 61 },
                    { 4, 3, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vẻ mặt chú mèo trông ngây thơ khi đòi ăn", true, true, false, false, 109, "Mèo", "../../assets/Img/meo.jpeg", null, "Ân Phạm", 111 },
                    { 7, 3, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chim cánh cụt tập trung theo đàn nghỉ mát trên bờ biển", true, true, false, false, 23, "Chim cánh cụt", "../../assets/Img/chimcanhcut.jpeg", null, "Ân Phạm", 50 },
                    { 9, 4, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cô gái nóng bỏng trong bộ bikini", true, true, false, false, 299, "Bikini", "../../assets/Img/bikini.jpeg", null, "Ân Phạm", 9999 },
                    { 6, 5, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ảnh thẻ thời học sinh", true, true, false, false, 0, "Ảnh thẻ", "../../assets/Img/anhthe.jpeg", null, "Ân Phạm", 0 },
                    { 12, 6, 0, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim tự tháp một địa danh là di sản văn hóa và kì quan thiên nhiên của Việt Nam", true, true, false, false, 30, "Kim tự tháp", "../../assets/Img/kimtuthap.jpeg", null, "Ân Phạm", 45 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryId",
                table: "Images",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId",
                unique: true);
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
                name: "Likes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
