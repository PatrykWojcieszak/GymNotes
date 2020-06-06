using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class DodanieCoachingRequesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoachingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CoachId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachingRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Weight = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatisticsDyscyplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StatisticsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsDyscyplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsDyscyplines_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatisticsExercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    StatisticsDyscyplineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsExercises_StatisticsDyscyplines_StatisticsDyscyplineId",
                        column: x => x.StatisticsDyscyplineId,
                        principalTable: "StatisticsDyscyplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDyscyplines_StatisticsId",
                table: "StatisticsDyscyplines",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsExercises_StatisticsDyscyplineId",
                table: "StatisticsExercises",
                column: "StatisticsDyscyplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachingRequests");

            migrationBuilder.DropTable(
                name: "StatisticsExercises");

            migrationBuilder.DropTable(
                name: "StatisticsDyscyplines");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
