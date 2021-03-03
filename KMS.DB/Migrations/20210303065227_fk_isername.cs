using Microsoft.EntityFrameworkCore.Migrations;

namespace KMS.DB.Migrations
{
    public partial class fk_isername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KMS_UserPermission_KMS_User_Username1",
                table: "KMS_UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_KMS_UserPermission_Username1",
                table: "KMS_UserPermission");

            migrationBuilder.DropColumn(
                name: "Username1",
                table: "KMS_UserPermission");

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserPermission_Username",
                table: "KMS_UserPermission",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_KMS_UserPermission_KMS_User_Username",
                table: "KMS_UserPermission",
                column: "Username",
                principalTable: "KMS_User",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KMS_UserPermission_KMS_User_Username",
                table: "KMS_UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_KMS_UserPermission_Username",
                table: "KMS_UserPermission");

            migrationBuilder.AddColumn<string>(
                name: "Username1",
                table: "KMS_UserPermission",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KMS_UserPermission_Username1",
                table: "KMS_UserPermission",
                column: "Username1");

            migrationBuilder.AddForeignKey(
                name: "FK_KMS_UserPermission_KMS_User_Username1",
                table: "KMS_UserPermission",
                column: "Username1",
                principalTable: "KMS_User",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
