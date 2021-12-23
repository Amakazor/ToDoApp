using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    id_TaskList_number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.id_TaskList_number);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.TaskStatusId);
                    table.ForeignKey(
                        name: "FK_TaskStatus_TaskList_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "TaskList",
                        principalColumn: "id_TaskList_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_TaskList_UserId",
                        column: x => x.UserId,
                        principalTable: "TaskList",
                        principalColumn: "id_TaskList_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StatusTaskStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_TaskList_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskList",
                        principalColumn: "id_TaskList_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_TaskStatus_StatusTaskStatusId",
                        column: x => x.StatusTaskStatusId,
                        principalTable: "TaskStatus",
                        principalColumn: "TaskStatusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusTaskStatusId",
                table: "Task",
                column: "StatusTaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "TaskList");
        }
    }
}
