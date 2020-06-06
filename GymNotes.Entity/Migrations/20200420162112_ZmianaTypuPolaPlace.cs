using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class ZmianaTypuPolaPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievement_AchievementDyscypline_achievementDyscyplineId",
                table: "Achievement");

            migrationBuilder.DropForeignKey(
                name: "FK_AchievementDyscypline_AspNetUsers_ApplicationUserId",
                table: "AchievementDyscypline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AchievementDyscypline",
                table: "AchievementDyscypline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement");

            migrationBuilder.RenameTable(
                name: "AchievementDyscypline",
                newName: "AchievementDyscyplines");

            migrationBuilder.RenameTable(
                name: "Achievement",
                newName: "Achievements");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementDyscypline_ApplicationUserId",
                table: "AchievementDyscyplines",
                newName: "IX_AchievementDyscyplines_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Achievement_achievementDyscyplineId",
                table: "Achievements",
                newName: "IX_Achievements_achievementDyscyplineId");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Achievements",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AchievementDyscyplines",
                table: "AchievementDyscyplines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementDyscyplines_AspNetUsers_ApplicationUserId",
                table: "AchievementDyscyplines",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AchievementDyscyplines_achievementDyscyplineId",
                table: "Achievements",
                column: "achievementDyscyplineId",
                principalTable: "AchievementDyscyplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementDyscyplines_AspNetUsers_ApplicationUserId",
                table: "AchievementDyscyplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AchievementDyscyplines_achievementDyscyplineId",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AchievementDyscyplines",
                table: "AchievementDyscyplines");

            migrationBuilder.RenameTable(
                name: "Achievements",
                newName: "Achievement");

            migrationBuilder.RenameTable(
                name: "AchievementDyscyplines",
                newName: "AchievementDyscypline");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_achievementDyscyplineId",
                table: "Achievement",
                newName: "IX_Achievement_achievementDyscyplineId");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementDyscyplines_ApplicationUserId",
                table: "AchievementDyscypline",
                newName: "IX_AchievementDyscypline_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "Place",
                table: "Achievement",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AchievementDyscypline",
                table: "AchievementDyscypline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievement_AchievementDyscypline_achievementDyscyplineId",
                table: "Achievement",
                column: "achievementDyscyplineId",
                principalTable: "AchievementDyscypline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementDyscypline_AspNetUsers_ApplicationUserId",
                table: "AchievementDyscypline",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
