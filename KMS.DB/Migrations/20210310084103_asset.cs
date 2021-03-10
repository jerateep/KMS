using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KMS.DB.Migrations
{
    public partial class asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KMS_AssetType",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    Type_Name = table.Column<string>(maxLength: 100, nullable: true),
                    Type_Desc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_AssetType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "KMS_MSTKey",
                columns: table => new
                {
                    KeyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    Key_Code = table.Column<string>(maxLength: 100, nullable: true),
                    Key_Desc = table.Column<string>(maxLength: 100, nullable: true),
                    Key_Box = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_MSTKey", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "KMS_MSTLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    LocationId_Code = table.Column<string>(maxLength: 100, nullable: true),
                    LocationId_Desc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_MSTLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "KMS_MSTASSET",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    Cod_create = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_create = table.Column<DateTime>(nullable: true),
                    Cod_update = table.Column<string>(maxLength: 25, nullable: true),
                    Dtm_update = table.Column<DateTime>(nullable: true),
                    Asset_Code = table.Column<string>(maxLength: 100, nullable: true),
                    Asset_Desc = table.Column<string>(maxLength: 100, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    KeyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KMS_MSTASSET", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_KMS_MSTASSET_KMS_MSTKey_KeyId",
                        column: x => x.KeyId,
                        principalTable: "KMS_MSTKey",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMS_MSTASSET_KMS_MSTLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "KMS_MSTLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KMS_MSTASSET_KMS_AssetType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "KMS_AssetType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KMS_MSTASSET_KeyId",
                table: "KMS_MSTASSET",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_MSTASSET_LocationId",
                table: "KMS_MSTASSET",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_MSTASSET_TypeId",
                table: "KMS_MSTASSET",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KMS_MSTASSET");

            migrationBuilder.DropTable(
                name: "KMS_MSTKey");

            migrationBuilder.DropTable(
                name: "KMS_MSTLocation");

            migrationBuilder.DropTable(
                name: "KMS_AssetType");
        }
    }
}
