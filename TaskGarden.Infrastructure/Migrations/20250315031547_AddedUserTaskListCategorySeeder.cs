using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTaskListCategorySeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLists_Categories_CategoryId",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskListCategories",
                table: "UserTaskListCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskListCategories_UserId",
                table: "UserTaskListCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTaskListCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TaskLists",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskListCategories",
                table: "UserTaskListCategories",
                columns: new[] { "UserId", "TaskListId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23db6bf5-1bbd-478d-9b13-5e7d39b9adf7", "AQAAAAIAAYagAAAAEOQ3xIC3YXDJ6ezzInu4uZhl+7CRe22kaW+Zi2Nuki95d1uWbDg9cFzFk7xk6MWkdQ==", "de08e79d-4a53-4f97-a188-9928beeafd0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "502307c2-48f8-461f-9efc-09205823864a", "AQAAAAIAAYagAAAAEOGtq/sjmCRK5a2JdwgBK0c+dlrqjMepSkmxwOBk7lEPVdF1+cWqpIg26AZiQG3t4w==", "01a6124c-ced6-4ea8-90ab-1458bc0748b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b48e31f2-d0be-4ce2-add3-80fc5bee4a23", "AQAAAAIAAYagAAAAEEkwhlXKwdaLZ4rR0CVDHF1swuXOkUoxtWMEED2cWwAezKoy+F4fProQ3zCiw1KLYg==", "46166c3a-ccc7-41fb-9976-b11fd514ed54" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1876), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1882) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1890), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1891) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1894), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1894) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1896), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1897) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1898), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1901), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1901) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1902), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1904), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1905), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1906) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1907), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2956), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2957) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2963), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2965), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2966), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2966) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2967), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2968), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2968) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2969), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2970), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2971), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2971) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2972), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2973), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2974), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2975) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2976), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2976) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2977), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2977) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2978), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2979), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3011), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3012) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3013), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3013) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3013), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3015), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3016), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3016) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3017), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3018), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3018) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3019), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3020), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3021), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3021) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3022), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3023), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3024), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3025) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3025), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3027), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3027) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3028), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3028) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3028), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(3029) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2789), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2789) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2798), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2798) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2799), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2800), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2801), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2802), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2803), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2803) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2804), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2820), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2821), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2821), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2822), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2823) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2818), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2819), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2807), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2808), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2808) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2809), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2809) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2809), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2810), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2811), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2812) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2812), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2812) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2813), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2814), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2815), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2816), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2816) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2817), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2817) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2805), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2805) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2806), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2806) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2265), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2269), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2270), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2335), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2337), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2343) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2344), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2345) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2350), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2352), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2353), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2424), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2424) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2425), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2426) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2427), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2427) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2428), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2428) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2429), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2430) });

            migrationBuilder.InsertData(
                table: "UserTaskListCategories",
                columns: new[] { "CategoryId", "TaskListId", "UserId", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2639), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2640) },
                    { 1, 2, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2641), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2641) },
                    { 2, 3, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2642), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2642) },
                    { 2, 4, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2643), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2643) },
                    { 3, 5, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644) },
                    { 3, 6, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2645) },
                    { 4, 7, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2645), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646) },
                    { 5, 8, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646) },
                    { 8, 11, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2649), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2649) },
                    { 8, 12, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650) },
                    { 9, 13, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651) },
                    { 10, 14, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651) },
                    { 6, 9, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2647), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2647) },
                    { 7, 10, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2648), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2648) }
                });

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
                name: "FK_TaskLists_Categories_CategoryId",
                table: "TaskLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskListCategories",
                table: "UserTaskListCategories");

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 1, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 2, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 3, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 4, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 5, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 6, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 4, 7, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 5, 8, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 9, 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 10, 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 6, 9, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 7, 10, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTaskListCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TaskLists",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskListCategories",
                table: "UserTaskListCategories",
                column: "Id");

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
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3260), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3265), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3267), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3268), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3270), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3271), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3272), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3274), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3275), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3277), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3278), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3279), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3280), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3281) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3282), new DateTime(2025, 3, 15, 2, 39, 25, 111, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskListCategories_UserId",
                table: "UserTaskListCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLists_Categories_CategoryId",
                table: "TaskLists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
