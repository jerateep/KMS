using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KMS.DB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KMS_Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MenuUrl = table.Column<string>(maxLength: 50, nullable: true),
                    MenuIcon = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "KMS_Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    PermissionName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_Permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "KMS_User",
                columns: table => new
                {
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: false),
                    FName = table.Column<string>(maxLength: 50, nullable: true),
                    LName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    UserImage = table.Column<byte[]>(nullable: true),
                    AddressL1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressL2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_User", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "KMS_UserMenu",
                columns: table => new
                {
                    UmId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_UserMenu", x => x.UmId);
                    table.ForeignKey(
                        name: "FK_KMS_UserMenu_KMS_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "KMS_Menu",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMS_UserMenu_KMS_User_Username",
                        column: x => x.Username,
                        principalTable: "KMS_User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KMS_UserPermission",
                columns: table => new
                {
                    UpId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Username1 = table.Column<string>(nullable: true),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_UserPermission", x => x.UpId);
                    table.ForeignKey(
                        name: "FK_KMS_UserPermission_KMS_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "KMS_Permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMS_UserPermission_KMS_User_Username1",
                        column: x => x.Username1,
                        principalTable: "KMS_User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserMenu_MenuId",
                table: "KMS_UserMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserMenu_Username",
                table: "KMS_UserMenu",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserPermission_PermissionId",
                table: "KMS_UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserPermission_Username1",
                table: "KMS_UserPermission",
                column: "Username1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KMS_UserMenu");

            migrationBuilder.DropTable(
                name: "KMS_UserPermission");

            migrationBuilder.DropTable(
                name: "KMS_Menu");

            migrationBuilder.DropTable(
                name: "KMS_Permission");

            migrationBuilder.DropTable(
                name: "KMS_User");
        }
    }
}
