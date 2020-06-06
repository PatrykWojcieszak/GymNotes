using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNotes.Entity.Migrations
{
    public partial class DodaniePolubienOpinii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "UserOpinions");

            migrationBuilder.CreateTable(
                name: "UserOpinionLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    UserOpinionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOpinionLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOpinionLikes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOpinionLikes_UserOpinions_UserOpinionId",
                        column: x => x.UserOpinionId,
                        principalTable: "UserOpinions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOpinionLikes_ApplicationUserId",
                table: "UserOpinionLikes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOpinionLikes_UserOpinionId",
                table: "UserOpinionLikes",
                column: "UserOpinionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOpinionLikes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "UserOpinions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
