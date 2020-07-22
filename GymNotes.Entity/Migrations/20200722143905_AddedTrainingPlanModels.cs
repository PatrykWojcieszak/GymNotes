using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class AddedTrainingPlanModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TrainingPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingWeeks_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TrainingWeekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDays_TrainingWeeks_TrainingWeekId",
                        column: x => x.TrainingWeekId,
                        principalTable: "TrainingWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    Tempo = table.Column<string>(nullable: true),
                    Rest = table.Column<int>(nullable: false),
                    RPE = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TrainingDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingExercises_TrainingDays_TrainingDayId",
                        column: x => x.TrainingDayId,
                        principalTable: "TrainingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_TrainingWeekId",
                table: "TrainingDays",
                column: "TrainingWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_TrainingDayId",
                table: "TrainingExercises",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CreatorId",
                table: "TrainingPlans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_OwnerId",
                table: "TrainingPlans",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWeeks_TrainingPlanId",
                table: "TrainingWeeks",
                column: "TrainingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExercises");

            migrationBuilder.DropTable(
                name: "TrainingDays");

            migrationBuilder.DropTable(
                name: "TrainingWeeks");

            migrationBuilder.DropTable(
                name: "TrainingPlans");
        }
    }
}
