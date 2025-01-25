using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskGarden.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskListRelationToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskListItems_AspNetUsers_UserId",
                table: "TaskListItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskListItems_UserId",
                table: "TaskListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskListItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TaskLists",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskLists_CategoryId",
                table: "TaskLists",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskListItems_CompletedById",
                table: "TaskListItems",
                column: "CompletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskListItems_AspNetUsers_CompletedById",
                table: "TaskListItems",
                column: "CompletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_Categories_CategoryId",
                table: "TaskLists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskListItems_AspNetUsers_CompletedById",
                table: "TaskListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_Categories_CategoryId",
                table: "TaskLists");

            migrationBuilder.DropIndex(
                name: "IX_TaskLists_CategoryId",
                table: "TaskLists");

            migrationBuilder.DropIndex(
                name: "IX_TaskListItems_CompletedById",
                table: "TaskListItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TaskLists");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskListItems",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskListItems_UserId",
                table: "TaskListItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskListItems_AspNetUsers_UserId",
                table: "TaskListItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
