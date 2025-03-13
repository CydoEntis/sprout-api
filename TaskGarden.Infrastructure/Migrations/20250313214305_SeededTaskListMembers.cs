using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededTaskListMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01c714ca-2912-4c17-ab29-b4fc6518726c", "AQAAAAIAAYagAAAAEA9iSgUIa+20Cd4c0TLET8KUwmcqXVvvdNTd7k5VUQxg7o7vIFzkaewqnUJmIRGF+w==", "a695b8e6-795d-451f-837d-dcef423e2757" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b15fd5a1-8dd9-4cdd-9b05-ae1898c3ec74", "AQAAAAIAAYagAAAAEJhv84jDo/GWIcuE4fMlICqlCsZtskTIXBsfyoQGg0RgCGCCJ/3lQwm3n5c+ZjQZHw==", "e4d8c9a3-2003-4c56-afcc-8a09603ec3fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1547723-881a-4e87-8dbc-a20c899ea936", "AQAAAAIAAYagAAAAEGBiaUigNTRipVzJKZPHrVhA9lFq8xmM4ZQjR1+uKbiOiR687LQ+3BMzD2WsTizgEA==", "82454142-df6d-4521-a727-f7c23136419f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3625), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3642) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3645), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3648), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3649), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3652), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3654), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3654) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3655), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3656) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3657), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3658) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3659), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(3659) });

            migrationBuilder.InsertData(
                table: "TaskListMembers",
                columns: new[] { "TaskListId", "UserId", "CreatedAt", "Id", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5052), 1, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5052) },
                    { 2, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5054), 2, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5054) },
                    { 3, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5055), 3, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5055) },
                    { 4, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5056), 4, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5057) },
                    { 5, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5058), 5, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5058) },
                    { 6, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5059), 6, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5059) },
                    { 7, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5060), 7, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5060) },
                    { 8, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5061), 8, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5062) },
                    { 11, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5082), 25, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5082) },
                    { 12, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5083), 26, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5083) },
                    { 13, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5084), 27, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5084) },
                    { 14, "1b503418-dc0f-4187-93c0-2e30070b2835", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5085), 28, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5085) },
                    { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5079), 23, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5079) },
                    { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5080), 24, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5081) },
                    { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5065), 11, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5065) },
                    { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5066), 12, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5066) },
                    { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5067), 13, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5068) },
                    { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5068), 14, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5069) },
                    { 1, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5070), 15, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5070) },
                    { 2, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5071), 16, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5071) },
                    { 3, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5072), 17, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5072) },
                    { 4, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5073), 18, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5074) },
                    { 5, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5074), 19, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5075) },
                    { 6, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5076), 20, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5076) },
                    { 7, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5077), 21, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5077) },
                    { 8, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5078), 22, 2, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5078) },
                    { 9, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5062), 9, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5063) },
                    { 10, "9e22a16c-da04-4232-b479-95c3a7b89259", new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5064), 10, 0, new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(5064) }
                });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4669), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4674), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4676), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4678), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4680), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4749), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4749) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4751), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4751) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4752), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4822), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4824), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4826), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4828), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4828) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4829), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4889), new DateTime(2025, 3, 13, 21, 43, 4, 811, DateTimeKind.Utc).AddTicks(4889) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.DeleteData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd331e48-0dc0-4271-9655-72f7a3aa96e7", "AQAAAAIAAYagAAAAEAGj9hUAbZOawCvur4Z7aeVYYOiAM7XMERP/q6V9fHK9R99Y7KEDQxnm3dXBFL8DRA==", "3737a9a4-df25-4630-bb5b-2937f185277e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0bd948f-3d72-4418-8eeb-7cd1e87b5960", "AQAAAAIAAYagAAAAEGMXbAQIp0PBtbKmJEo2Mmt30MopjwZ87cHRHR04gKWWe54eNmxIppRaQxPoh8WlfA==", "ce171b80-c4f6-4497-97ed-db7b4f93b341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c02711cc-1f42-4b38-bee9-551e397473a4", "AQAAAAIAAYagAAAAELgidyGumqrMXjRET8XT64qFTiJqBSofLjFYcm4ms0+7MbzTXPjoh/PqQqUwsNrpBg==", "039f7261-7fb2-4ae4-90e0-4557f6cb6def" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5482), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5486) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5499), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5507), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5510), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5512), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5512) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5514), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5516), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5518), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(5518) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6304), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6310), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6312), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6314), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6315) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6316), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6372) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6374), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6375) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6381), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6381) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6383), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6384), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6386), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6386) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6388), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6389), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6391), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6393), new DateTime(2025, 3, 13, 21, 42, 28, 602, DateTimeKind.Utc).AddTicks(6393) });
        }
    }
}
