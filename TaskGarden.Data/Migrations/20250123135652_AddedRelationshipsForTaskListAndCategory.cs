using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskGarden.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipsForTaskListAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaskLists_UserId",
                table: "TaskLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_AspNetUsers_UserId",
                table: "TaskLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_AspNetUsers_UserId",
                table: "TaskLists");

            migrationBuilder.DropIndex(
                name: "IX_TaskLists_UserId",
                table: "TaskLists");
        }
    }
}
