using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class BetterTaskListControlInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_User_OwnerUserID",
                table: "TaskList");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TaskList_TaskListID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TaskListID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TaskListID",
                table: "User");

            migrationBuilder.CreateTable(
                name: "TasklistUser",
                columns: table => new
                {
                    MembersUserID = table.Column<int>(type: "int", nullable: false),
                    TasklistsMemberedTaskListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasklistUser", x => new { x.MembersUserID, x.TasklistsMemberedTaskListID });
                    table.ForeignKey(
                        name: "FK_TasklistUser_TaskList_TasklistsMemberedTaskListID",
                        column: x => x.TasklistsMemberedTaskListID,
                        principalTable: "TaskList",
                        principalColumn: "TaskListID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasklistUser_User_MembersUserID",
                        column: x => x.MembersUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasklistUser_TasklistsMemberedTaskListID",
                table: "TasklistUser",
                column: "TasklistsMemberedTaskListID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_User_OwnerUserID",
                table: "TaskList",
                column: "OwnerUserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_User_OwnerUserID",
                table: "TaskList");

            migrationBuilder.DropTable(
                name: "TasklistUser");

            migrationBuilder.AddColumn<int>(
                name: "TaskListID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TaskListID",
                table: "User",
                column: "TaskListID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_User_OwnerUserID",
                table: "TaskList",
                column: "OwnerUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TaskList_TaskListID",
                table: "User",
                column: "TaskListID",
                principalTable: "TaskList",
                principalColumn: "TaskListID");
        }
    }
}
