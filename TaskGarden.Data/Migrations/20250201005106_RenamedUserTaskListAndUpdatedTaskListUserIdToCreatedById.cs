using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskGarden.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedUserTaskListAndUpdatedTaskListUserIdToCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_AspNetUsers_UserId",
                table: "TaskLists");

            migrationBuilder.DropTable(
                name: "UserTaskLists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TaskLists",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_UserId",
                table: "TaskLists",
                newName: "IX_TaskLists_CreatedById");

            migrationBuilder.CreateTable(
                name: "TaskListAssignments",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TaskListId = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskListAssignments", x => new { x.UserId, x.TaskListId });
                    table.ForeignKey(
                        name: "FK_TaskListAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskListAssignments_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskListAssignments_TaskListId",
                table: "TaskListAssignments",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_AspNetUsers_CreatedById",
                table: "TaskLists",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_AspNetUsers_CreatedById",
                table: "TaskLists");

            migrationBuilder.DropTable(
                name: "TaskListAssignments");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "TaskLists",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLists_CreatedById",
                table: "TaskLists",
                newName: "IX_TaskLists_UserId");

            migrationBuilder.CreateTable(
                name: "UserTaskLists",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TaskListId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskLists", x => new { x.UserId, x.TaskListId });
                    table.ForeignKey(
                        name: "FK_UserTaskLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskLists_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskLists_TaskListId",
                table: "UserTaskLists",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_AspNetUsers_UserId",
                table: "TaskLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
