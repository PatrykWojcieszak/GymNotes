using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class DodaniePupils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "CoachingRequests",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileCoachId = table.Column<string>(nullable: true),
                    ProfilePupilId = table.Column<string>(nullable: true),
                    Partnership = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pupils_AspNetUsers_ProfileCoachId",
                        column: x => x.ProfileCoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pupils_AspNetUsers_ProfilePupilId",
                        column: x => x.ProfilePupilId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_ProfileCoachId",
                table: "Pupils",
                column: "ProfileCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_ProfilePupilId",
                table: "Pupils",
                column: "ProfilePupilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "CoachingRequests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
