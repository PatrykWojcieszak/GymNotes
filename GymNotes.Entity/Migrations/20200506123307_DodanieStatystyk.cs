using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class DodanieStatystyk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDisciplines_Statistics_StatisticsId",
                table: "StatisticsDisciplines");

            migrationBuilder.AlterColumn<int>(
                name: "StatisticsId",
                table: "StatisticsDisciplines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDisciplines_Statistics_StatisticsId",
                table: "StatisticsDisciplines",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDisciplines_Statistics_StatisticsId",
                table: "StatisticsDisciplines");

            migrationBuilder.AlterColumn<int>(
                name: "StatisticsId",
                table: "StatisticsDisciplines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDisciplines_Statistics_StatisticsId",
                table: "StatisticsDisciplines",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
