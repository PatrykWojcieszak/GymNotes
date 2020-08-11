using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class FixTrainingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistories_PlannedTrainings_PlannedTrainingId",
                table: "TrainingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingExerciseId",
                table: "TrainingHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedTrainingId",
                table: "TrainingHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistories_PlannedTrainings_PlannedTrainingId",
                table: "TrainingHistories",
                column: "PlannedTrainingId",
                principalTable: "PlannedTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories",
                column: "TrainingExerciseId",
                principalTable: "TrainingExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistories_PlannedTrainings_PlannedTrainingId",
                table: "TrainingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingExerciseId",
                table: "TrainingHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlannedTrainingId",
                table: "TrainingHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistories_PlannedTrainings_PlannedTrainingId",
                table: "TrainingHistories",
                column: "PlannedTrainingId",
                principalTable: "PlannedTrainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingHistories_TrainingExercises_TrainingExerciseId",
                table: "TrainingHistories",
                column: "TrainingExerciseId",
                principalTable: "TrainingExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
