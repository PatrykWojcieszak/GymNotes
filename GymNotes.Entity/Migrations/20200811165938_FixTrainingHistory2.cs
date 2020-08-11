using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class FixTrainingHistory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories");

            migrationBuilder.DropIndex(
                name: "IX_TrainingHistories_TrainingExerciseId",
                table: "TrainingHistories");

            migrationBuilder.DropColumn(
                name: "TrainingExerciseId",
                table: "TrainingHistories");

            migrationBuilder.AddColumn<int>(
                name: "TrainingHistoryId",
                table: "TrainingExercises",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_TrainingHistoryId",
                table: "TrainingExercises",
                column: "TrainingHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_TrainingHistories_TrainingHistoryId",
                table: "TrainingExercises",
                column: "TrainingHistoryId",
                principalTable: "TrainingHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_TrainingHistories_TrainingHistoryId",
                table: "TrainingExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingExercises_TrainingHistoryId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "TrainingHistoryId",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<int>(
                name: "TrainingExerciseId",
                table: "TrainingHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingHistories_TrainingExerciseId",
                table: "TrainingHistories",
                column: "TrainingExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories",
                column: "TrainingExerciseId",
                principalTable: "TrainingExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
