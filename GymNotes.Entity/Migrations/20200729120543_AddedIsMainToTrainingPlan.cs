using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class AddedIsMainToTrainingPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "TrainingPlans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "TrainingPlans",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "TrainingPlans");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "TrainingPlans");
        }
    }
}
