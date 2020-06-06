using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class PoprawienieModeluPolubien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOpinionLikes_UserOpinions_UserOpinionId",
                table: "UserOpinionLikes");

            migrationBuilder.AlterColumn<int>(
                name: "UserOpinionId",
                table: "UserOpinionLikes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpinionLikes_UserOpinions_UserOpinionId",
                table: "UserOpinionLikes",
                column: "UserOpinionId",
                principalTable: "UserOpinions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOpinionLikes_UserOpinions_UserOpinionId",
                table: "UserOpinionLikes");

            migrationBuilder.AlterColumn<int>(
                name: "UserOpinionId",
                table: "UserOpinionLikes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserOpinionLikes_UserOpinions_UserOpinionId",
                table: "UserOpinionLikes",
                column: "UserOpinionId",
                principalTable: "UserOpinions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
