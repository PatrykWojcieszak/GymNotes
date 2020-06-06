using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class PoprawienieDodanieModeliDlaCzatu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ReceipentId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ReceipentId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "ReceipentId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "ReceipentId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ReceipentId",
                table: "Contacts",
                column: "ReceipentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ReceipentId",
                table: "Contacts",
                column: "ReceipentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
