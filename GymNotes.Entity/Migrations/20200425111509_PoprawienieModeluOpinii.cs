using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class PoprawienieModeluOpinii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "UserOpinions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "UserOpinions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOpinions_CommenterId",
                table: "UserOpinions",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOpinions_ProfileUserId",
                table: "UserOpinions",
                column: "ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpinions_AspNetUsers_CommenterId",
                table: "UserOpinions",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpinions_AspNetUsers_ProfileUserId",
                table: "UserOpinions",
                column: "ProfileUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOpinions_AspNetUsers_CommenterId",
                table: "UserOpinions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOpinions_AspNetUsers_ProfileUserId",
                table: "UserOpinions");

            migrationBuilder.DropIndex(
                name: "IX_UserOpinions_CommenterId",
                table: "UserOpinions");

            migrationBuilder.DropIndex(
                name: "IX_UserOpinions_ProfileUserId",
                table: "UserOpinions");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUserId",
                table: "UserOpinions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "UserOpinions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
