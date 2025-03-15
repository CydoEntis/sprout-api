using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIsValidFromSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVaild",
                table: "Sessions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b503418-dc0f-4187-93c0-2e30070b2835",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60be6696-95e2-4d01-a263-a86bfa15c1eb", "AQAAAAIAAYagAAAAELZzlAo3gHWkt42UveWsR+n7HeRmWz52VUHrQNI2YTnDb0KfabkiQxuoJTD2KY5Rmg==", "2889e08f-8ecf-43ba-b13b-9b9a5d3dcc2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fcec36-7eef-42d8-8086-cd2226b88d00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5d48f94-b30c-4c96-a551-bce8d7e20714", "AQAAAAIAAYagAAAAEMa7BkdOzqqBOZkpqnezsLCnEZoRy1EaFCrpZh9hGR/2rrCx6K5DcP41dmRzbIkCYA==", "26b9c8e6-8f7e-4f79-9637-9ee022c3bb10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e22a16c-da04-4232-b479-95c3a7b89259",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7546b970-2a72-44a8-aa0c-5e7f7acba506", "AQAAAAIAAYagAAAAEOneriB5vRg6ltc4D5nCI5mIgIZlsBqF143jcVj0cKMoqAN4D4WWBgnQep3ahHDy8A==", "c85cf87a-8890-4a66-abca-61212555aff1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8100), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8112), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8113) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8114), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8114) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8116), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8118), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8118) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8120), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8120) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8121), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8121) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8123), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8223), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8225), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9683), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9686), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9686) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9688), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9689), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9690), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9691), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9692), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9693), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9693) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9694), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9695), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9696), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9697), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9698), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9699), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9701), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9701) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9702), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9703), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9704), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9705), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9705) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9706), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9706) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9707), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9708), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9709), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9709) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9710), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9711), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9712), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9713), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9713) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9714), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9715), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9716), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9717), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9718), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9719), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9453), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9453) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9456), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9456) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9457), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9458), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9459), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9460), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9461), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9461) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9462), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9529), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9530), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9531), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9531) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9532), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9527), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9528), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9465), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9465) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9466), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9466), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9467), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 1, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9468), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 2, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9469), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 3, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9470), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 4, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9471), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 5, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9522), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9523) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 6, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9524), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 7, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9525), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9525) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 8, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9526), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9463), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9463) });

            migrationBuilder.UpdateData(
                table: "TaskListMembers",
                keyColumns: new[] { "TaskListId", "UserId" },
                keyValues: new object[] { 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9464), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8693), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8694) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8697), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8698) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8699), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8699) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8760), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8762), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8771), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8777), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8777) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8778), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8779), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8781), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8782), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8784), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8785), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8787), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9277), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9281), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9282), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9283), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9283) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9284), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9285), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 4, 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9286), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 5, 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9287), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9287) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9289), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9290), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 9, 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9291), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 10, 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9291), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 6, 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9287), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 7, 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9288), new DateTime(2025, 3, 15, 23, 18, 51, 946, DateTimeKind.Utc).AddTicks(9289) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVaild",
                table: "Sessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2265), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2269), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2270), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2335), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2337), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2343) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2344), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2345) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2350), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2352), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2353), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2424), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2424) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2425), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2426) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2427), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2427) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2428), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2428) });

            migrationBuilder.UpdateData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2429), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2430) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 1, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2639), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 1, 2, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2641), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 3, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2642), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 2, 4, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2643), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2643) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 5, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 3, 6, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 4, 7, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2645), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 5, 8, "1b503418-dc0f-4187-93c0-2e30070b2835" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2646) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 11, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2649), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2649) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 8, 12, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 9, 13, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2650), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 10, 14, "40fcec36-7eef-42d8-8086-cd2226b88d00" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2651) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 6, 9, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2647), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2647) });

            migrationBuilder.UpdateData(
                table: "UserTaskListCategories",
                keyColumns: new[] { "CategoryId", "TaskListId", "UserId" },
                keyValues: new object[] { 7, 10, "9e22a16c-da04-4232-b479-95c3a7b89259" },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2648), new DateTime(2025, 3, 15, 3, 15, 46, 972, DateTimeKind.Utc).AddTicks(2648) });
        }
    }
}
