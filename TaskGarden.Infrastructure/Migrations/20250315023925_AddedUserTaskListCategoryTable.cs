using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTaskListCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTaskListCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TaskListId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskListCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskListCategories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskListCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskListCategories_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6175d8ab-5dd1-40b2-b226-be0d541b0e7b", "AQAAAAIAAYagAAAAEAKtiECaueqYdQ++bgQSy5qeGjclvBL6lge+Zb/Rq2aoiG6iPVYYFVYTkxMwBRSxQA==", "a55f72c4-5370-460f-846f-38215a2cffcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7a198a4-ea0a-45eb-8bfe-b1c9a6b39e74", "AQAAAAIAAYagAAAAEKiWeAL/6B0HFtEMK/yhUPIGAOOkIaoQPmbEsd3RHdsX3RXQkYVckNbN1sqYWyfzsA==", "8d0c0beb-24d7-480d-9b5a-a0405f6c4c52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "662385aa-29ac-41dc-acde-b87e092ddcf4", "AQAAAAIAAYagAAAAENDw7meyJSwJ5N/sp9yj4rRQDUXBWNs0N/4C64rE1uoxsDOO7YiVrcah1jC0e3MMpg==", "8628106e-23c5-4979-a314-7303cbc7defb" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2982), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2988) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2995), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2995) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2996), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2997) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2998), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(2998) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3001), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3003), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3004) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3005), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3005) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3006), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3008), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3009), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3009) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3812), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3814), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3815), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3816) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3817) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3818), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3819), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3820), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3821), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3822), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3823), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3824), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3825), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3826), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3827), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3827) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3828), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3829), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3830), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3831), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3832) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3832), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3833), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3835), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3835) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3836), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3836) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3837), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3838), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3839), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3839) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3840), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3841) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3842), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3843), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3844), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3845), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3845) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3846), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3596), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3604), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3605), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3606), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3607), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3608), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3608) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3609), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3610), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3626), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3626), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3627), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3628) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3628), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3628) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3624), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3625), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3613), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3614), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3615), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3616), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3616), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3617), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3618), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3619), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3620), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3621), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3621) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3622), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3623), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3611), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3611) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3612), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3260), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3265), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3267), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3268), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3270), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3271), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3272), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3274), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3275), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3277), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3278), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3279), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3280), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3281) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3282), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskListCategories_CategoryId",
                table: "UserTaskListCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskListCategories_TaskListId",
                table: "UserTaskListCategories",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskListCategories_UserId",
                table: "UserTaskListCategories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTaskListCategories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea134c6a-a912-481e-9c1d-5552218c4ca8", "AQAAAAIAAYagAAAAEOY59L4gcaRoETXuKgjbzDJJ2P4IpuEBiFN3ERktQ2D0/ryqAFYpT65iJ7W8EihRUQ==", "3b1fbdd2-3f94-4ab8-9532-665e7680ad7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10924ff3-3809-4302-8ce1-f1ae4383f547", "AQAAAAIAAYagAAAAEBWrzVxb6sPlt/lgKWoadIoP5XYbqPhGOG0V3ZXtfx8EIiizLk8pXjiPO3lpNvN7QQ==", "100aae54-f659-47e5-9964-5ec844fe7078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e410f0f-8cb1-4fa3-a431-db95485d4a9a", "AQAAAAIAAYagAAAAEOdqidL96n2T/HTrkms9YP5ebty61AYYEJk4PyjytxmHjtcAilubo89u6Hpi1jL9Fg==", "5b477896-9ba7-468b-960b-03c72044ffa6" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6092), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6105), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6107), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6110), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6112), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6112) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6115), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6117), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6120), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7367), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7371), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7373), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7374), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7376), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7377), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7378), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7380), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7381), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7383), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7384), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7385), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7386), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7388), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7388) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7389), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7390), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7391), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7393), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7394), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7395), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7396) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7397), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7398), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7399), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7399) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7400), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7401), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7403), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7404), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7405), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7406), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7408), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7409), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7410), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7411), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7412) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7180), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7183), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7185), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7186), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7187), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7188), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7189), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7191), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7191) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7210), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7211), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7211) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7212), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7213), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7208), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7209), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7194), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7195), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7197), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7198), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7198) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7199), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7200), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7201), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7202), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7203), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7204), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7205), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7207), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7192), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7193), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6771), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6776), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6779), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6781), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6782), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6839), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6852), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6854), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6856), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6859), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6863), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 3, 13, 21, 43, 38, 787, DateTimeKind.Utc).AddTicks(6865) });
        }
    }
}
