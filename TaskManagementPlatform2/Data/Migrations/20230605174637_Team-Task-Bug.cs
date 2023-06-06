using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementPlatform2.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamTaskBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Tasks_TaskId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TaskId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TeamMembers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "TeamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TaskId",
                table: "TeamMembers",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Tasks_TaskId",
                table: "TeamMembers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
