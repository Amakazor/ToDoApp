using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    TaskListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    OwnerUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.TaskListID);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    TaskStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TaskListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.TaskStatusID);
                    table.ForeignKey(
                        name: "FK_TaskStatus_TaskList_TaskListID",
                        column: x => x.TaskListID,
                        principalTable: "TaskList",
                        principalColumn: "TaskListID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    TaskListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_TaskList_TaskListID",
                        column: x => x.TaskListID,
                        principalTable: "TaskList",
                        principalColumn: "TaskListID");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AuthorUserID = table.Column<int>(type: "int", nullable: false),
                    StatusTaskStatusID = table.Column<int>(type: "int", nullable: false),
                    TaskListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_TaskList_TaskListID",
                        column: x => x.TaskListID,
                        principalTable: "TaskList",
                        principalColumn: "TaskListID");
                    table.ForeignKey(
                        name: "FK_Task_TaskStatus_StatusTaskStatusID",
                        column: x => x.StatusTaskStatusID,
                        principalTable: "TaskStatus",
                        principalColumn: "TaskStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_User_AuthorUserID",
                        column: x => x.AuthorUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_AuthorUserID",
                table: "Task",
                column: "AuthorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusTaskStatusID",
                table: "Task",
                column: "StatusTaskStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskListID",
                table: "Task",
                column: "TaskListID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_OwnerUserID",
                table: "TaskList",
                column: "OwnerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_TaskListID",
                table: "TaskStatus",
                column: "TaskListID");

            migrationBuilder.CreateIndex(
                name: "IX_User_TaskListID",
                table: "User",
                column: "TaskListID");

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
                name: "FK_User_TaskList_TaskListID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
