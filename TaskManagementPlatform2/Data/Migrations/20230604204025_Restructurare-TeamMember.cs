using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementPlatform2.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestructurareTeamMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTeamMember");

            migrationBuilder.DropTable(
                name: "TeamTeamMember");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "TeamMember",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "TeamMember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_TaskId",
                table: "TeamMember",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Tasks_TaskId",
                table: "TeamMember",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Tasks_TaskId",
                table: "TeamMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_TaskId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "TeamMember");

            migrationBuilder.CreateTable(
                name: "TaskTeamMember",
                columns: table => new
                {
                    MembersTeamMemberId = table.Column<int>(type: "int", nullable: false),
                    TasksTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTeamMember", x => new { x.MembersTeamMemberId, x.TasksTaskId });
                    table.ForeignKey(
                        name: "FK_TaskTeamMember_Tasks_TasksTaskId",
                        column: x => x.TasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTeamMember_TeamMember_MembersTeamMemberId",
                        column: x => x.MembersTeamMemberId,
                        principalTable: "TeamMember",
                        principalColumn: "TeamMemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTeamMember",
                columns: table => new
                {
                    MembersTeamMemberId = table.Column<int>(type: "int", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTeamMember", x => new { x.MembersTeamMemberId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_TeamTeamMember_TeamMember_MembersTeamMemberId",
                        column: x => x.MembersTeamMemberId,
                        principalTable: "TeamMember",
                        principalColumn: "TeamMemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTeamMember_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTeamMember_TasksTaskId",
                table: "TaskTeamMember",
                column: "TasksTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTeamMember_TeamsTeamId",
                table: "TeamTeamMember",
                column: "TeamsTeamId");
        }
    }
}
